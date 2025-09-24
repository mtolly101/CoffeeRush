using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
[RequireComponent(typeof(ParticleSystemRenderer))]
public class BoostBurst : MonoBehaviour
{
    [Header("Optional Visuals")]
    public Material ParticleMaterial;   // assign if you have a custom particle material
    public Sprite RoundSprite;          // or assign a round sprite to use as the texture

    [Header("Burst Tuning")]
    public int BurstCount = 100;
    public Color BoostColor = new(1f, 0.85f, 0.2f); // warm yellow/orange

    private ParticleSystem _ps = default!;
    private ParticleSystemRenderer _renderer = default!;
    private Material _runtimeMat; // cache to avoid re-allocs

    void Awake()
    {
        _ps = GetComponent<ParticleSystem>();
        _renderer = GetComponent<ParticleSystemRenderer>();
        Configure();
        // Ensure nothing plays on enable/awake:
        _ps.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        _ps.Clear(true);
    }

    private void Configure()
    {
        // MAIN
        var main = _ps.main;
        main.playOnAwake = false;                     // do not auto-play
        main.loop = true;                            // one-shot burst
        main.duration = 0.5f;
        main.startLifetime = new ParticleSystem.MinMaxCurve(0.3f, 0.6f);
        main.startSpeed = new ParticleSystem.MinMaxCurve(5f, 8f);
        main.startSize = new ParticleSystem.MinMaxCurve(0.1f, 0.2f);
        main.startColor = BoostColor;
        main.gravityModifier = 0f;
        main.simulationSpace = ParticleSystemSimulationSpace.World;
        main.maxParticles = 512;

        // EMISSION: no continuous emission; bursts will be set when Play is called
        var emission = _ps.emission;
        emission.enabled = true;
        emission.rateOverTime = 0f;
        emission.SetBursts(System.Array.Empty<ParticleSystem.Burst>());

        // SHAPE
        var shape = _ps.shape;
        shape.enabled = true;
        shape.shapeType = ParticleSystemShapeType.Sphere; // Or Circle for 2D
        shape.radius = 0.15f;

        // COLOR OVER LIFETIME
        var col = _ps.colorOverLifetime;
        col.enabled = true;
        var gradient = new Gradient();
        gradient.SetKeys(
            new[]
            {
                new GradientColorKey(BoostColor, 0f),
                new GradientColorKey(new Color(1f, 0.7f, 0f), 0.4f)
            },
            new[]
            {
                new GradientAlphaKey(1f, 0f),
                new GradientAlphaKey(0f, 1f)
            }
        );
        col.color = new ParticleSystem.MinMaxGradient(gradient);

        // SIZE OVER LIFETIME
        var sol = _ps.sizeOverLifetime;
        sol.enabled = true;
        var curve = new AnimationCurve(new Keyframe(0f, 1f), new Keyframe(1f, 0f));
        sol.size = new ParticleSystem.MinMaxCurve(1f, curve);

        // RENDERER
        _renderer.renderMode = ParticleSystemRenderMode.Billboard;

        if (RoundSprite != null)
        {
            // Build once and reuse
            if (_runtimeMat == null)
            {
                _runtimeMat = new Material(Shader.Find("Sprites/Default"));
                _runtimeMat.mainTexture = RoundSprite.texture;
            }
            _renderer.material = _runtimeMat;
        }
        else if (ParticleMaterial != null)
        {
            _renderer.material = ParticleMaterial;
        }
    }

    /// <summary>
    /// Plays a single burst at the given world position.
    /// Optional overrides let you change color and particle count per call.
    /// </summary>
    public void Play(Vector3 worldPosition, Color? colorOverride = null, int? countOverride = null)
    {
        transform.position = worldPosition;

        // Apply dynamic overrides
        var main = _ps.main;
        if (colorOverride.HasValue) main.startColor = colorOverride.Value;

        int count = countOverride ?? BurstCount;

        // Program a one-shot burst at t=0 for this play
        var emission = _ps.emission;
        emission.SetBursts(new[]
        {
            new ParticleSystem.Burst(0f, (short)count)
        });

        // Ensure clean start; then play (won’t auto-loop)
        _ps.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        _ps.Play(true);
    }

    /// <summary>
    /// Stops emission immediately and clears existing particles.
    /// Safe to call from other classes at any time.
    /// </summary>
    public void Stop()
    {
        _ps.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
    }

    void OnDestroy()
    {
        // Clean up runtime material if we created it
        if (_runtimeMat != null)
        {
            Destroy(_runtimeMat);
            _runtimeMat = null;
        }
    }
}
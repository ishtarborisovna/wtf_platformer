using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIParticleSystem : MaskableGraphic
{
    private ParticleSystem _particleSystem;
    private ParticleSystemRenderer _particleSystemRenderer;
    private ParticleSystem.MainModule _main;
    private ParticleSystem.Particle[] _particles;

    public Texture ParticleImage;
    public override Texture mainTexture
    {
        get { return ParticleImage; }
    }


    protected override void Awake()
    {
        base.Awake();

        _particleSystem = GetComponent<ParticleSystem>();
        _main = _particleSystem.main;

        _particleSystemRenderer = GetComponent<ParticleSystemRenderer>();
        _particleSystemRenderer.enabled = false;

        int maxCount = _main.maxParticles;
        _particles = new ParticleSystem.Particle[maxCount];
    }

    protected override void OnPopulateMesh(VertexHelper vh)
    {
        vh.Clear();

        

        int particlesCount = _particleSystem.GetParticles(_particles);

        for (int i = 0; i < particlesCount; i++)
        {
            var particle = _particles[i];

            Vector3 particlePosition = particle.position;

            Color vertexColor = particle.GetCurrentColor(_particleSystem) * color;
            Vector3 particleSize = particle.GetCurrentSize3D(_particleSystem);

            Vector2[] vertexUV = _simpleUV;
            Quaternion rotation = Quaternion.AngleAxis(particle.rotation, Vector3.forward);

            UIVertex[] quadVerts = new UIVertex[4];
            for (int j = 0; j < 4; j++)
            {
                Vector3 cornerPosition = rotation * Vector3.Scale(particleSize, _quadCorners[j]);
                Vector3 vertexPosition = cornerPosition + particlePosition;
                vertexPosition.z = 0;
                quadVerts[j] = new UIVertex();
                quadVerts[j].color = vertexColor;
                quadVerts[j].uv0 = vertexUV[j];
                quadVerts[j].position = vertexPosition;
            }
            vh.AddUIVertexQuad(quadVerts);
        }

    }

    protected void Update()
    {
        SetVerticesDirty();
    }

    private Vector3[] _quadCorners = new Vector3[]
{
    new Vector3(-.5f, -.5f, 0),
    new Vector3(-.5f, .5f, 0),
    new Vector3(.5f, .5f, 0),
    new Vector3(.5f, -.5f, 0)
};

    private Vector2[] _simpleUV = new Vector2[]
    {
    new Vector2(0,0),
    new Vector2(0,1),
    new Vector2(1,1),
    new Vector2(1,0),
    };


}

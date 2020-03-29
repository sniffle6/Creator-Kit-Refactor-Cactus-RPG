using UnityEngine;

namespace _RPG.Scripts.MonoBehaviours
{
    public class HighlightableObject : MonoBehaviour
    {
        protected Renderer[] Renderers;

        private int _rimColorId;
        private int _rimPowId;
        private int _rimIntensityId;

        private Color[] _originalRimColor;
        private float[] _savedRimIntensity;

        private MaterialPropertyBlock _propertyBlock;

        private void Start()
        {
            Renderers = GetComponentsInChildren<Renderer>();

            _rimColorId = Shader.PropertyToID("_RimColor");
            _rimPowId = Shader.PropertyToID("_RimPower");
            _rimIntensityId = Shader.PropertyToID("_RimIntensity");
        
            _propertyBlock = new MaterialPropertyBlock();
        
            _originalRimColor = new Color[Renderers.Length];
            _savedRimIntensity = new float[Renderers.Length];

            for (var i = 0; i < Renderers.Length; i++)
            {
                var rend = Renderers[i];
                var mat = rend.sharedMaterial;

                if (!mat.HasProperty(_rimColorId))
                {
                    Renderers[i] = null;
                    continue;
                }

                _originalRimColor[i] = mat.GetColor(_rimColorId);
            
                _propertyBlock.SetColor(_rimColorId, mat.GetColor(_rimColorId));
                _propertyBlock.SetFloat(_rimPowId, mat.GetFloat(_rimPowId));
                _propertyBlock.SetFloat(_rimIntensityId, mat.GetFloat(_rimIntensityId));
            
                rend.SetPropertyBlock(_propertyBlock);


            }
        }
    
    
        public void Highlight()
        {
            for (var i = 0; i < Renderers.Length; i++)
            {
                var rend = Renderers[i];
                
                if(!rend)
                    continue;
                
                rend.GetPropertyBlock(_propertyBlock);
                
                _propertyBlock.SetColor(_rimColorId, _originalRimColor[i]);
                _propertyBlock.SetFloat(_rimPowId, _propertyBlock.GetFloat(_rimPowId) * 0.25f);

                _savedRimIntensity[i] = _propertyBlock.GetFloat(_rimIntensityId);
                _propertyBlock.SetFloat(_rimIntensityId, 1.0f);
            
                rend.SetPropertyBlock(_propertyBlock);
            }
        }


        public void DeHighlight()
        {
            for (var i = 0; i < Renderers.Length; i++)
            {
                var rend = Renderers[i];
            
                if(!rend)
                    continue;
            
                _propertyBlock.SetColor(_rimColorId, Color.white);
                _propertyBlock.SetFloat(_rimPowId, _propertyBlock.GetFloat(_rimPowId) * 4.0f);
                _propertyBlock.SetFloat(_rimIntensityId, _savedRimIntensity[i]);
            
                rend.SetPropertyBlock(_propertyBlock);
            }
        }
    
    }
}


































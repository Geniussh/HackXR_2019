using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Vision.VisionEffect.ColorBlind
{

	public class VisionSimulator : Vision.VisionEffect.PostEffectsBase
	{
		public enum ColorBlindMode
		{
			Protanope,
			Deuteranope,
		}
		[SerializeField]
		public ColorBlindMode BlindMode = ColorBlindMode.Protanope;

		[SerializeField]
		public float BlindIntensity = 0.0f;

		[SerializeField]
		public Shader ColorBlindShader;
		private Material ColorBlindMat;

		public static readonly string ColorBlindShaderName = "Hidden/GULTI/ColorBlindSimulator";


		#region Overrides
		
		protected override bool CheckResources ()
		{
			CheckSupport(false);
			ColorBlindShader = Shader.Find(ColorBlindShaderName);
			ColorBlindMat = CreateMaterial(ColorBlindShader, ColorBlindMat);
			return ColorBlindMat != null;
		}
		
		#endregion

		#region Monobehavior

		void OnDisable()
		{
			if(ColorBlindMat != null)
			{
#if UNITY_EDITOR
				if(!UnityEditor.EditorApplication.isPlaying)
					DestroyImmediate(ColorBlindMat, true);
				else
#endif
				Destroy(ColorBlindMat);
			}
		}

        void OnRenderImage(RenderTexture _src, RenderTexture _dst)
		{
			if(ColorBlindMat == null)
			{
				if(!CheckResources())
				{
					NotSupported();
					return;
				}
			}

			switch (BlindMode)
			{
				case ColorBlindMode.Protanope:
					ColorBlindMat.shaderKeywords = new string[] { "CB_TYPE_ONE" };
					break;
				case ColorBlindMode.Deuteranope:
					ColorBlindMat.shaderKeywords = new string[] { "CB_TYPE_TWO" };
					break;
			}

			//Intensity Set
			//ColorBlindMat.SetFloat("_BlindIntensity", BlindIntensity);

			Graphics.Blit(_src, _dst, ColorBlindMat);
		}

        #endregion

        public void Slider_Changed(float newValue)
        {
            ColorBlindMat.SetFloat("_BlindIntensity", newValue);
        }

    }
}
﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Nireus
{
    public enum GradientType
    {
        Horizontal,
        Vertical
    }


    public enum GradientBlend
    {
        Override,
        Add,
        Multiply
    }


    
        [AddComponentMenu("UI/Effects/UGUI_Gradient")]
        public class Gradient : BaseMeshEffect
        {
            [SerializeField]
        GradientType _gradientType;


            [SerializeField]
        GradientBlend _blendMode = GradientBlend.Multiply;


            [SerializeField]
            [Range(-1, 1)]
            float _offset = 0f;


            [SerializeField]
            UnityEngine.Gradient _effectGradient = new UnityEngine.Gradient()
            { colorKeys  = new GradientColorKey[] { new GradientColorKey(Color.black, 0), new GradientColorKey(Color.white, 1) } };


            #region Properties  
            public GradientBlend BlendMode
            {
                get { return _blendMode; }
                set { _blendMode = value; }
            }


            public UnityEngine.Gradient EffectGradient
            {
                get { return _effectGradient; }
                set { _effectGradient = value; }
            }


            public GradientType GradientType
            {
                get { return _gradientType; }
                set { _gradientType = value; }
            }


            public float Offset
            {
                get { return _offset; }
                set { _offset = value; }
            }
            #endregion


            public override void ModifyMesh(VertexHelper helper)
            {
                if (!IsActive() || helper.currentVertCount == 0)
                    return;


                List<UIVertex> _vertexList = new List<UIVertex>();


                helper.GetUIVertexStream(_vertexList);


                int nCount = _vertexList.Count;
                switch (GradientType)
                {
                    case GradientType.Horizontal:
                        {
                            float left = _vertexList[0].position.x;
                            float right = _vertexList[0].position.x;
                            float x = 0f;
                            for (int i = nCount - 1; i >= 1; --i)
                            {
                                x = _vertexList[i].position.x;


                                if (x > right) right = x;
                                else if (x < left) left = x;
                            }
                            float width = 1f / (right - left);
                            UIVertex vertex = new UIVertex();


                            for (int i = 0; i < helper.currentVertCount; i++)
                            {
                                helper.PopulateUIVertex(ref vertex, i);


                                vertex.color = BlendColor(vertex.color, EffectGradient.Evaluate((vertex.position.x - left) * width - Offset));


                                helper.SetUIVertex(vertex, i);
                            }
                        }
                        break;


                    case GradientType.Vertical:
                        {
                            float bottom = _vertexList[0].position.y;
                            float top = _vertexList[0].position.y;
                            float y = 0f;
                            for (int i = nCount - 1; i >= 1; --i)
                            {
                                y = _vertexList[i].position.y;


                                if (y > top) top = y;
                                else if (y < bottom) bottom = y;
                            }
                            float height = 1f / (top - bottom);
                            UIVertex vertex = new UIVertex();


                            for (int i = 0; i < helper.currentVertCount; i++)
                            {
                                helper.PopulateUIVertex(ref vertex, i);


                                vertex.color = BlendColor(vertex.color, EffectGradient.Evaluate((vertex.position.y - bottom) * height - Offset));


                                helper.SetUIVertex(vertex, i);
                            }
                        }
                        break;
                }
            }


            Color BlendColor(Color colorA, Color colorB)
            {
                switch (BlendMode)
                {
                    default: return colorB;
                    case GradientBlend.Add: return colorA + colorB;
                    case GradientBlend.Multiply: return colorA * colorB;
                }
            }
        }
    }


/*
 * 作者：Peter Xiang
 * 联系方式：565067150@qq.com
 * 文档: https://github.com/PxGame
 * 创建时间: 2020/9/2 13:50:19
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XMLib;
using XMLib.AM;

using FPPhysics;
using Vector2 = FPPhysics.Vector2;
using Vector3 = FPPhysics.Vector3;
using Quaternion = FPPhysics.Quaternion;
using Matrix4x4 = FPPhysics.Matrix4x4;
using UVector2 = UnityEngine.Vector2;
using UVector3 = UnityEngine.Vector3;
using UQuaternion = UnityEngine.Quaternion;
using UMatrix4x4 = UnityEngine.Matrix4x4;
using Mathf = FPPhysics.FPUtility;
using Single = FPPhysics.Fix64;

namespace AliveCell
{
    /// <summary>
    /// EffectObject
    /// </summary>
    public class EffectObject : TObject, IUObjectLogicUpdate
    {
        public Single lifeTime;
        public int bindObjId;
        public Vector3 localPosition;
        public Quaternion localRotation;
        public BindPointType bindPointType;
        public bool syncObjFrame;
        public bool useObjRotation;
        public bool updateTransform;

        protected ActionMachineObject bindObj;

        public override void OnReset()
        {
            base.OnReset();

            lifeTime = 0;
            bindObjId = UObjectSystem.noneID;
            localPosition = Vector3.zero;
            localRotation = Quaternion.identity;
            bindPointType = BindPointType.None;
            syncObjFrame = true;

            useObjRotation = false;
            updateTransform = false;

            bindObj = null;
        }

        public override void OnInitialized()
        {
            base.OnInitialized();
            bindObj = world.uobj.Get<ActionMachineObject>(bindObjId);
        }

        public bool CanUpdate()
        {
            if (syncObjFrame && bindObj != null)
            {
                return (bindObj.machine.eventTypes & ActionMachineEvent.FrameChanged) != 0;
            }

            return true;
        }

        public void OnLogicUpdate(Single deltaTime)
        {
            if (CanUpdate())
            {
                UpdateLifeTime(deltaTime);
            }
        }

        private void UpdateLifeTime(Single deltaTime)
        {
            lifeTime -= deltaTime;
            if (lifeTime <= 0)
            {
                Destory();
            }
        }
    }
}
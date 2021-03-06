// MvxImageViewImageTargetBinding.cs
// (c) Copyright Cirrious Ltd. http://www.cirrious.com
// MvvmCross is licensed using Microsoft Public License (Ms-PL)
// Contributions and inspirations noted in readme.md and license.txt
// 
// Project Lead - Stuart Lodge, @slodge, me@slodge.com

using System;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Widget;
using Cirrious.MvvmCross.Binding.Interfaces;
using Cirrious.MvvmCross.Interfaces.Platform.Diagnostics;

namespace Cirrious.MvvmCross.Binding.Droid.Target
{
    public class MvxImageViewImageTargetBinding
        : MvxBaseAndroidTargetBinding
    {
        private readonly ImageView _imageView;

        public MvxImageViewImageTargetBinding(ImageView imageView)
        {
            _imageView = imageView;
        }

        public override MvxBindingMode DefaultMode
        {
            get { return MvxBindingMode.OneWay; }
        }

        public override Type TargetType
        {
            get { return typeof (string); }
        }

        public override void SetValue(object value)
        {
            if (value == null)
            {
                MvxBindingTrace.Trace(MvxTraceLevel.Warning, "Null value passed to ImageView binding");
                return;
            }

            var stringValue = value as string;
            if (string.IsNullOrWhiteSpace(stringValue))
            {
                MvxBindingTrace.Trace(MvxTraceLevel.Warning, "Empty value passed to ImageView binding");
                return;
            }

            var drawableResourceName = GetImageAssetName(stringValue);

            var assetStream = AndroidGlobals.ApplicationContext.Assets.Open(drawableResourceName);

            var options = new BitmapFactory.Options() { InPurgeable = true };
            var bitmap = BitmapFactory.DecodeStream(assetStream, null, options);
            var drawable = new BitmapDrawable(Resources.System, bitmap);
            _imageView.SetImageDrawable(drawable);
           
        }

        private static string GetImageAssetName(string rawImage)
        {
            return rawImage.TrimStart('/');
        }
    }
}
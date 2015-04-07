﻿// Copyright (c) Wiesław Šoltés. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Test2d;

namespace Test.Controls
{
    internal class LayerElement : FrameworkElement
    {
        public static readonly DependencyProperty RendererProperty =
            DependencyProperty.Register(
                "Renderer",
                typeof(IRenderer),
                typeof(LayerElement),
                new FrameworkPropertyMetadata(
                    null,
                    FrameworkPropertyMetadataOptions.AffectsRender |
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsArrange |
                    FrameworkPropertyMetadataOptions.SubPropertiesDoNotAffectRender));

        public IRenderer Renderer
        {
            get { return (IRenderer)GetValue(RendererProperty); }
            set { SetValue(RendererProperty, value); }
        }

        private Layer _layer = null;

        public LayerElement()
        {
            DataContextChanged += (s, e) => Initialize();
            Unloaded += (s, e) => DeInitialize();
        }

        private void Invalidate(object sender, InvalidateLayerEventArgs e)
        {
            this.InvalidateVisual();
        }

        private void Initialize()
        {
            if (_layer != null)
            {
                DeInitialize();
            }

            var layer = DataContext as Layer;
            if (layer != null)
            {
                _layer = layer;
                _layer.InvalidateLayer += Invalidate;
            }
        }

        private void DeInitialize()
        {
            if (_layer != null)
            {
                _layer.InvalidateLayer -= Invalidate;
                _layer = null;
            }
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            Render(drawingContext);
        }

        private void Render(DrawingContext drawingContext)
        {
            var layer = DataContext as Layer;
            if (layer != null && layer.IsVisible)
            {
                if (Renderer != null)
                {
                    Renderer.Render(drawingContext, layer);
                }
            }
        }
    }

    public partial class ContainerControl : UserControl
    {
        public ContainerControl()
        {
            InitializeComponent();

            Loaded += (s, e) => InitializeCanvas(); 
        }

        private void InitializeCanvas()
        {
            var editor = DataContext as Editor;

            canvas.PreviewMouseLeftButtonDown +=
                (s, e) =>
                {
                    canvas.Focus();
                    if (editor.IsLeftAvailable())
                    {
                        var p = e.GetPosition(canvas);
                        editor.Left(p.X, p.Y);
                    }
                };

            canvas.PreviewMouseRightButtonDown +=
                (s, e) =>
                {
                    canvas.Focus();
                    if (editor.IsRightAvailable())
                    {
                        var p = e.GetPosition(canvas);
                        editor.Right(p.X, p.Y);
                    }
                };

            canvas.PreviewMouseMove +=
                (s, e) =>
                {
                    canvas.Focus();
                    if (editor.IsMoveAvailable())
                    {
                        var p = e.GetPosition(canvas);
                        editor.Move(p.X, p.Y);
                    }
                };

            canvas.Focus();
        }
    }
}

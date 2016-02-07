﻿// Copyright (c) Wiesław Šoltés. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
using Xunit;

namespace Core2D.UnitTests
{
    public class LayerTests
    {
        [Fact]
        [Trait("Core2D", "Project")]
        public void Inherits_From_Selectable()
        {
            var target = new Layer();
            Assert.True(target is Selectable);
        }

        [Fact]
        [Trait("Core2D", "Project")]
        public void Shapes_Not_Null()
        {
            var target = new Layer();
            Assert.NotNull(target.Shapes);
        }

        [Fact]
        [Trait("Core2D", "Project")]
        public void Setting_IsVisible_Should_Invalidate_Layer()
        {
            var target = Layer.Create("Layer1");

            bool raised = false;

            target.InvalidateLayer += (sender, e) =>
            {
                raised = true;
            };

            target.IsVisible = false;

            Assert.True(raised);
        }

        [Fact]
        [Trait("Core2D", "Project")]
        public void Invalidate_Raises_InvalidateLayer_Event()
        {
            var target = Layer.Create("Layer1");

            bool raised = false;

            target.InvalidateLayer += (sender, e) =>
            {
                raised = true;
            };

            target.Invalidate();

            Assert.True(raised);
        }

        [Fact]
        [Trait("Core2D", "Project")]
        public void Invalidate_Sets_EventArgs()
        {
            var target = Layer.Create("Layer1");

            InvalidateLayerEventArgs args = null;

            target.InvalidateLayer += (sender, e) =>
            {
                args = e;
            };

            target.Invalidate();

            Assert.NotNull(args);
            Assert.True(args is InvalidateLayerEventArgs);
        }
    }
}

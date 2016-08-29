﻿using Core2D.Project;

namespace Core2D.Renderer
{
    /// <summary>
    /// Container presenter base class.
    /// </summary>
    public abstract class ContainerPresenter
    {
        /// <summary>
        /// Renders a container using provided drawing context.
        /// </summary>
        /// <param name="dc">The drawing context.</param>
        /// <param name="renderer">The shape renderer.</param>
        /// <param name="container">The container to render.</param>
        /// <param name="dx">The X coordinate offset.</param>
        /// <param name="dy">The Y coordinate offset.</param>
        public abstract void Render(object dc, ShapeRenderer renderer, XContainer container, double dx, double dy);
    }
}
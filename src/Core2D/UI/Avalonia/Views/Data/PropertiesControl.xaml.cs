﻿using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Core2D.UI.Avalonia.Views.Data
{
    /// <summary>
    /// Interaction logic for <see cref="PropertiesControl"/> xaml.
    /// </summary>
    public class PropertiesControl : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PropertiesControl"/> class.
        /// </summary>
        public PropertiesControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialize the Xaml components.
        /// </summary>
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BetterWpfControls
{
    public enum ScrollDirection
    {
        Left,
        Right
    }

    /// <summary>
    /// Flat button with a chevron drawn in <see cref="Control.Foreground"/>, so it follows the
    /// text colour of its surroundings in light and dark themes. Default scroll button of the
    /// <see cref="Panels.ScrollablePanel"/>.
    /// </summary>
    public class ScrollButton : Button
    {
        #region .ctors

        static ScrollButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ScrollButton), new FrameworkPropertyMetadata(typeof(ScrollButton)));
        }

        #endregion .ctors

        #region Properties

        #region Direction

        public ScrollDirection Direction
        {
            get { return (ScrollDirection)GetValue(DirectionProperty); }
            set { SetValue(DirectionProperty, value); }
        }

        public static readonly DependencyProperty DirectionProperty =
            DependencyProperty.Register("Direction", typeof(ScrollDirection), typeof(ScrollButton), new UIPropertyMetadata(ScrollDirection.Left));

        #endregion Direction

        #region HoverBackground

        public Brush HoverBackground
        {
            get { return (Brush)GetValue(HoverBackgroundProperty); }
            set { SetValue(HoverBackgroundProperty, value); }
        }

        public static readonly DependencyProperty HoverBackgroundProperty =
            DependencyProperty.Register("HoverBackground", typeof(Brush), typeof(ScrollButton), new UIPropertyMetadata(null));

        #endregion HoverBackground

        #region CornerRadius

        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(ScrollButton), new UIPropertyMetadata(new CornerRadius(4)));

        #endregion CornerRadius

        #endregion Properties
    }
}

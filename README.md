# BetterWpfControls

A collection of WPF controls and panels: some are new, others are enhanced versions of the controls
that ship with WPF. The library targets **.NET 10** (`net10.0-windows`).

## Getting started

Reference the project from your WPF application:

```xml
<ProjectReference Include="..\BetterWpfControls\BetterWpfControls\BetterWpfControls.csproj" />
```

and import the namespaces in XAML:

```xml
xmlns:bwc="clr-namespace:BetterWpfControls;assembly=BetterWpfControls"
xmlns:bwcPanels="clr-namespace:BetterWpfControls.Panels;assembly=BetterWpfControls"
```

The default styles live in `Themes/Generic.xaml` and are picked up automatically. The solution
contains a demo application (`BetterWpfControls.Demo`) that shows every control.

```bash
dotnet build BetterWpfControls.sln
```

## Controls

### TabControl

A `TabControl` for many tabs:

- **Scrolling.** When the tabs do not fit, scroll buttons appear at both ends of the strip.
- **Quick links.** A menu button lists every tab, so you can jump to one that is scrolled out of
  view. It is shown only while tabs are cut off; `ShowQuickLinksButton="False"` hides it.
- **Locked tabs.** `bwcPanels:ScrollablePanel.IsLocked="True"` keeps a tab in place while the others
  scroll.
- `SelectItemOnScroll` decides whether scrolling also selects the next tab.
- `ScrollToLeftContent` / `ScrollToRightContent` replace the scroll buttons with your own content.
  A button inside it marked `bwcPanels:ScrollablePanel.IsScroller="True"` gets the scroll command.

```xml
<bwc:TabControl ItemsSource="{Binding Documents}" SelectedItem="{Binding SelectedDocument}">
    <bwc:TabItem Header="Summary" bwcPanels:ScrollablePanel.IsLocked="True" />
</bwc:TabControl>
```

### MenuButton

A button that opens a menu for a small set of related commands. Each item runs `Command` with the
item as parameter.

### SplitButton

A button with a primary command and a menu of variations, for a command that is mostly used one way.

### ScrollButton

A flat button with a chevron (`Direction="Left"` or `"Right"`). It is the default scroll button of
`ScrollablePanel` and the `TabControl`, and can be used on its own.

### TreeListBox

Shows very large trees with virtualization: the tree is flattened into a list on the fly, and the
list reuses the virtualization of `ListBox` / `VirtualizingStackPanel`.

### Panels

- **ScrollablePanel** – scrolls its children when there is not enough room for all of them; the
  header panel of the `TabControl`.
- **ResizablePanel** – shrinks its children when there is not enough room, longest ones first,
  until all have the same size.

### Other controls

- **AutoCompleteTextBox** – a text box that shows suggestions while typing.
- **ImageButton** – a chrome-less button that shows an image.
- **CollapsibleGridSplitter** – collapses a grid row or column with one click.
- **ContentAdorner** – an `Adorner` that shows any `UIElement`.
- **ContentBox** – a button that shows additional content in a popup.

## Theming

The menu and the scroll buttons draw their chevrons in `Foreground`, so they follow the text colour
of their surroundings. The hover backgrounds are semi-transparent and work on light and dark
backgrounds. For a theme of your own, set the brushes in a style and bind them to your theme
resources:

| Control | Property | Used for |
|---------|----------|----------|
| `MenuButton` | `Foreground` | Chevron and item text |
| | `HoverBackground` | Toggle button under the mouse or while the menu is open |
| | `PopupBackground`, `PopupBorderBrush` | Menu popup |
| | `ItemHighlightBackground` | Menu item under the mouse |
| `ScrollButton` | `Foreground` | Chevron |
| | `HoverBackground` | Button under the mouse |
| | `CornerRadius` | Rounded corners of the hover background |

```xml
<Style TargetType="{x:Type bwc:ScrollButton}">
    <Setter Property="Foreground" Value="{DynamicResource MyTextBrush}" />
    <Setter Property="HoverBackground" Value="{DynamicResource MyHoverBrush}" />
</Style>
```

A `TabControl` with a custom template uses its own `MenuButton` as quick-links button
(`PART_QuickLinksHost`); give that one the style:

```xml
<bwc:MenuButton x:Name="PART_QuickLinksHost" Style="{StaticResource MyMenuButtonStyle}" />
```

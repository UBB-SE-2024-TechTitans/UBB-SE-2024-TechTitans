namespace TechTitans.Views.Components;

public partial class Piechart : ContentView
{
	public Piechart()
	{
		InitializeComponent();
	}

    public static readonly BindableProperty ProgressProperty = BindableProperty.Create(nameof(Progress), typeof(float), typeof(Piechart));
    public static readonly BindableProperty SizeProperty = BindableProperty.Create(nameof(Size), typeof(int), typeof(Piechart));
    public static readonly BindableProperty ThicknessProperty = BindableProperty.Create(nameof(Thickness), typeof(int), typeof(Piechart));
    public static readonly BindableProperty ProgressColorProperty = BindableProperty.Create(nameof(ProgressColor), typeof(Color), typeof(Piechart));
    public static readonly BindableProperty ProgressLeftColorProperty = BindableProperty.Create(nameof(ProgressLeftColor), typeof(Color), typeof(Piechart));
    public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(Piechart));

    public float Progress
    {
        get { return (float)GetValue(ProgressProperty); }
        set { SetValue(ProgressProperty, value); }
    }

    public int Size
    {
        get { return (int)GetValue(SizeProperty); }
        set { SetValue(SizeProperty, value); }
    }

    public int Thickness
    {
        get { return (int)GetValue(ThicknessProperty); }
        set { SetValue(ThicknessProperty, value); }
    }

    public Color ProgressColor
    {
        get { return (Color)GetValue(ProgressColorProperty); }
        set { SetValue(ProgressColorProperty, value); }
    }

    public Color ProgressLeftColor
    {
        get { return (Color)GetValue(ProgressLeftColorProperty); }
        set { SetValue(ProgressLeftColorProperty, value); }
    }

    public Color TextColor
    {
        get { return (Color)GetValue(TextColorProperty); }
        set { SetValue(TextColorProperty, value); }
    }

    protected override void OnPropertyChanged(string propertyName = null)
    {
        base.OnPropertyChanged(propertyName);

        if (propertyName == SizeProperty.PropertyName)
        {
            HeightRequest = Size;
            WidthRequest = Size;
        }
    }
}
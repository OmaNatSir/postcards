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

namespace DrawOwnMeadow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MyNewMeadow : Window
    {
        private enum enumBackgrounds
        {
            bkgrLandscape1, bkgrLandscape2, bkgrForgetMeNot, bkgrBlueBell, bkgrWhiteLily, bkgrRose, bkgrNarcissus,
            bkgrBrightGreen, bkgrBlueRadialGradient, bkgrFuchsiaLinearGradient, bkgrLinearRainbow, bkgrRadialRainbow,
            bkgrLightGreen, bkgrLightRose, bkgrLightSkyBlue, bkgrLightYellow, bkgrBlack, bkgrWhiteSmoke, bkgrBlue,
            bkgrGreen, bkgrYellow, bkgrOrange, bkgrChocolate, bkgrRed
        }
        private enumBackgrounds bkgrCanvasDrawingArea;

        private enum enumDrawElement
        {
            ForgetMeNot, BlueBell, WhiteLily, Rose, Narcissus,
            ForgetMeNotStem, BlueBellStem, WhiteLilyStem, RoseStem, NarcissusStem,
            ForgetMeNotThreeStems, BlueBellThreeStems, WhiteLilyThreeStems, RoseThreeStems, NarcissusThreeStems,
            SimpleGrassApartSimple, ShortGrassSimple, SimpleGrassLinGradient, SimpleGrass,
            SimpleGrassApart, ShortGrassDirty, DirtyGreenGrass
        }
        private enumDrawElement drawSelectedElement;

        #region Drawing Brushes
        // DrawingBrushes for backgrounds
        private DrawingBrush drbrLandscape1;
        private DrawingBrush drbrLandscape2;

        //DrawingBrushes for drawings in canvasDrawingArea
        private DrawingBrush drbrForgetMeNot;
        private DrawingBrush drbrBlueBell;
        private DrawingBrush drbrWhiteLily;
        private DrawingBrush drbrRose;
        private DrawingBrush drbrNarcissus;
        private DrawingBrush drbrForgetMeNotStem;
        private DrawingBrush drbrBlueBellStem;
        private DrawingBrush drbrWhiteLilyStem;
        private DrawingBrush drbrRoseStem;
        private DrawingBrush drbrNarcissusStem;
        private DrawingBrush drbrForgetMeNotThreeStems;
        private DrawingBrush drbrBlueBellThreeStems;
        private DrawingBrush drbrWhiteLilyThreeStems;
        private DrawingBrush drbrRoseThreeStems;
        private DrawingBrush drbrNarcissusThreeStems;

        private DrawingBrush drbrSimpleGrassApartSimple;
        private DrawingBrush drbrShortGrassSimple;
        private DrawingBrush drbrSimpleGrassLinGradient;
        private DrawingBrush drbrSimpleGrass;
        private DrawingBrush drbrSimpleGrassApart;
        private DrawingBrush drbrShortGrassDirty;
        private DrawingBrush drbrDirtyGreenGrass;
        #endregion Drawing Brushes

        //Rectangle rectChosenElement = null;
        Rectangle rectChosenElementForMoving = null;

        //variable for moving  
        private bool moving = false;

        public MyNewMeadow()
        {
            InitializeComponent();
            // get the brushes
            drbrLandscape1 = this.FindResource("Landscape1") as DrawingBrush;
            drbrLandscape2 = this.FindResource("Landscape2") as DrawingBrush;
            cboBackgrounds.SelectedIndex = 0;

            //DrawingBrushes for drawings in canvasDrawingArea
            drbrForgetMeNot = this.FindResource("ForgetMeNot") as DrawingBrush;
            drbrForgetMeNotStem = this.FindResource("ForgetMeNotStem") as DrawingBrush;
            drbrForgetMeNotThreeStems = this.FindResource("ForgetMeNotThreeStems") as DrawingBrush;
            drbrBlueBell = this.FindResource("BlueBell") as DrawingBrush;
            drbrBlueBellStem = this.FindResource("BlueBellStem") as DrawingBrush;
            drbrBlueBellThreeStems = this.FindResource("BlueBellThreeStems") as DrawingBrush;
            drbrWhiteLily = this.FindResource("WhiteLily") as DrawingBrush;
            drbrWhiteLilyStem = this.FindResource("WhiteLilyStem") as DrawingBrush;
            drbrWhiteLilyThreeStems = this.FindResource("WhiteLilyThreeStems") as DrawingBrush;
            drbrRose = this.FindResource("Rose") as DrawingBrush;
            drbrRoseStem = this.FindResource("RoseStem") as DrawingBrush;
            drbrRoseThreeStems = this.FindResource("RoseThreeStems") as DrawingBrush;
            drbrNarcissus = this.FindResource("Narcissus") as DrawingBrush;
            drbrNarcissusStem = this.FindResource("NarcissusStem") as DrawingBrush;
            drbrNarcissusThreeStems = this.FindResource("NarcissusThreeStems") as DrawingBrush;
            drbrSimpleGrassApartSimple = this.FindResource("SimpleGrassApartSimple") as DrawingBrush;
            drbrShortGrassSimple = this.FindResource("ShortGrassSimple") as DrawingBrush;
            drbrSimpleGrassLinGradient = this.FindResource("SimpleGrassLinGradient") as DrawingBrush;
            drbrSimpleGrass = this.FindResource("SimpleGrass") as DrawingBrush;
            drbrSimpleGrassApart = this.FindResource("SimpleGrassApart") as DrawingBrush;
            drbrShortGrassDirty = this.FindResource("ShortGrassDirty") as DrawingBrush;
            drbrDirtyGreenGrass = this.FindResource("DirtyGreenGrass") as DrawingBrush;

            drawSelectedElement = enumDrawElement.ForgetMeNot;

        }

        private void cboBackgrounds_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //ComboBox cmb = (ComboBox)sender; ComboBoxItem cboBackgroundsItem = (ComboBoxItem)cmb.SelectedItem;
            ComboBoxItem cboBackgroundsItem = (ComboBoxItem)cboBackgrounds.SelectedItem;

            bkgrCanvasDrawingArea = (enumBackgrounds)Enum.Parse(typeof(enumBackgrounds), cboBackgroundsItem.Name);
            switch (bkgrCanvasDrawingArea)
            {
                case enumBackgrounds.bkgrLandscape1:
                    canvasDrawingArea.Background = drbrLandscape1;
                    break;
                case enumBackgrounds.bkgrLandscape2:
                    canvasDrawingArea.Background = drbrLandscape2;
                    break;
                case enumBackgrounds.bkgrForgetMeNot:
                    canvasDrawingArea.Background = new BrushConverter().ConvertFromString("#FF8FC71C") as Brush;
                    break;
                case enumBackgrounds.bkgrBlueBell:
                    canvasDrawingArea.Background = new BrushConverter().ConvertFromString("#FF7CEA83") as Brush;
                    break;
                case enumBackgrounds.bkgrWhiteLily:
                    canvasDrawingArea.Background = new BrushConverter().ConvertFromString("#FFA1A15E") as Brush;
                    break;
                case enumBackgrounds.bkgrRose:
                    canvasDrawingArea.Background = new BrushConverter().ConvertFromString("#FF4CB04C") as Brush;
                    break;
                case enumBackgrounds.bkgrNarcissus:
                    canvasDrawingArea.Background = new BrushConverter().ConvertFromString("#FF9FC82D") as Brush;
                    break;
                case enumBackgrounds.bkgrBrightGreen:
                    canvasDrawingArea.Background = Brushes.GreenYellow;
                    break;
                case enumBackgrounds.bkgrBlueRadialGradient:
                    RadialGradientBrush blueRadialBrush = new RadialGradientBrush();
                    blueRadialBrush.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FFA1DDF9"), 0.0));
                    blueRadialBrush.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FF0083FF"), 1));
                    canvasDrawingArea.Background = blueRadialBrush;
                    break;
                case enumBackgrounds.bkgrFuchsiaLinearGradient:
                    LinearGradientBrush fuchsiaBrush = new LinearGradientBrush();
                    fuchsiaBrush.GradientStops.Add(new GradientStop(Colors.White, 0.0));
                    fuchsiaBrush.GradientStops.Add(new GradientStop(Colors.Fuchsia, 0.5));
                    fuchsiaBrush.GradientStops.Add(new GradientStop(Colors.White, 1.0));
                    canvasDrawingArea.Background = fuchsiaBrush;
                    break;
                case enumBackgrounds.bkgrLinearRainbow:
                    LinearGradientBrush rainbowLinearBrush = new LinearGradientBrush();
                    rainbowLinearBrush.GradientStops.Add(new GradientStop(Colors.Red, 0.0));
                    rainbowLinearBrush.GradientStops.Add(new GradientStop(Colors.Orange, 0.167));
                    rainbowLinearBrush.GradientStops.Add(new GradientStop(Colors.Yellow, 0.334));
                    rainbowLinearBrush.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FF0ADD0A"), 0.5));
                    rainbowLinearBrush.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FF13BCFD"), 0.667));
                    rainbowLinearBrush.GradientStops.Add(new GradientStop(Colors.Blue, 0.893));
                    rainbowLinearBrush.GradientStops.Add(new GradientStop(Colors.BlueViolet, 1.0));
                    rainbowLinearBrush.EndPoint = new Point(0, 1);
                    rainbowLinearBrush.StartPoint = new Point(1, 0);
                    canvasDrawingArea.Background = rainbowLinearBrush;
                    break;
                case enumBackgrounds.bkgrRadialRainbow:
                    RadialGradientBrush rainbowRadialBrush = new RadialGradientBrush();
                    rainbowRadialBrush.GradientStops.Add(new GradientStop(Colors.Red, 0.0));
                    rainbowRadialBrush.GradientStops.Add(new GradientStop(Colors.Orange, 0.167));
                    rainbowRadialBrush.GradientStops.Add(new GradientStop(Colors.Yellow, 0.334));
                    rainbowRadialBrush.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FF0ADD0A"), 0.5));
                    rainbowRadialBrush.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FF13BCFD"), 0.667));
                    rainbowRadialBrush.GradientStops.Add(new GradientStop(Colors.Blue, 0.893));
                    rainbowRadialBrush.GradientStops.Add(new GradientStop(Colors.BlueViolet, 1.0));
                    canvasDrawingArea.Background = rainbowRadialBrush;
                    break;
                case enumBackgrounds.bkgrLightGreen:
                    canvasDrawingArea.Background = new BrushConverter().ConvertFromString("#FFDBFFA4") as Brush;
                    break;
                case enumBackgrounds.bkgrLightRose:
                    canvasDrawingArea.Background = new BrushConverter().ConvertFromString("#FFF9D3F8") as Brush;
                    break;
                case enumBackgrounds.bkgrLightSkyBlue:
                    canvasDrawingArea.Background = new BrushConverter().ConvertFromString("#7F92E3F8") as Brush;
                    break;
                case enumBackgrounds.bkgrLightYellow:
                    canvasDrawingArea.Background = new BrushConverter().ConvertFromString("#B2F8F492") as Brush;
                    break;
                case enumBackgrounds.bkgrBlack:
                    canvasDrawingArea.Background = Brushes.Black;
                    break;
                case enumBackgrounds.bkgrWhiteSmoke:
                    canvasDrawingArea.Background = Brushes.WhiteSmoke;
                    break;
                case enumBackgrounds.bkgrBlue:
                    canvasDrawingArea.Background = Brushes.Blue;
                    break;
                case enumBackgrounds.bkgrGreen:
                    canvasDrawingArea.Background = Brushes.Green;
                    break;
                case enumBackgrounds.bkgrYellow:
                    canvasDrawingArea.Background = Brushes.Yellow;
                    break;
                case enumBackgrounds.bkgrOrange:
                    canvasDrawingArea.Background = Brushes.Orange;
                    break;
                case enumBackgrounds.bkgrChocolate:
                    canvasDrawingArea.Background = Brushes.Chocolate;
                    break;
                case enumBackgrounds.bkgrRed:
                    canvasDrawingArea.Background = Brushes.Red;
                    break;
                default:
                    canvasDrawingArea.Background = Brushes.LightGray;
                    break;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Configure save file dialog box
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Meadow"; // Default file name
            dlg.DefaultExt = ".png"; // Default file extension
            dlg.Filter = "PNG Image|*.png";

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results 
            if (result == true)
            {
                // Save document 
                string filename = dlg.FileName;

                Rect rect = new Rect(canvasDrawingArea.Margin.Left, canvasDrawingArea.Margin.Top, canvasDrawingArea.ActualWidth, canvasDrawingArea.ActualHeight);
                RenderTargetBitmap rtb = new RenderTargetBitmap((int)rect.Right, (int)rect.Bottom, 96d, 96d, System.Windows.Media.PixelFormats.Default);
                rtb.Render(canvasDrawingArea);
                //endcode as PNG
                BitmapEncoder pngEncoder = new PngBitmapEncoder();
                pngEncoder.Frames.Add(BitmapFrame.Create(rtb));

                //save to memory stream
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                pngEncoder.Save(ms);
                ms.Close();
                System.IO.File.WriteAllBytes(filename, ms.ToArray());
            }

        }

        private void DrawFlower_Click(object sender, RoutedEventArgs e)
        {
            drawSelectedElement = (enumDrawElement)Enum.Parse(typeof(enumDrawElement), (sender as RadioButton).Name.ToString());
        }

        private void canvasDrawingArea_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Firstly, get the X,Y location of where the user clicked.
            Point pt = e.GetPosition((Canvas)sender);

            Shape elementToRender = null;
            // Configure the correct element to draw.
            switch (drawSelectedElement)
            {
                case enumDrawElement.ForgetMeNot:
                    elementToRender = new Rectangle { Fill = drbrForgetMeNot, Width = 8.26533, Height = 9.000026, MaxWidth = 16.10679, MaxHeight = 17.5385 };
                    break;
                case enumDrawElement.BlueBell:
                    elementToRender = new Rectangle { Fill = drbrBlueBell, Width = 21.00005, Height = 19.65142, MaxWidth = 40.92315, MaxHeight = 38.29506 };
                    break;
                case enumDrawElement.WhiteLily:
                    elementToRender = new Rectangle { Fill = drbrWhiteLily, Width = 89.99998, Height = 77.06007, MaxWidth = 175.3845, MaxHeight = 150.1683 };
                    break;
                case enumDrawElement.Rose:
                    elementToRender = new Rectangle { Fill = drbrRose, Width = 64.99995, Height = 55.19294, MaxWidth = 126.6665, MaxHeight = 107.5554 };
                    break;
                case enumDrawElement.Narcissus:
                    elementToRender = new Rectangle { Fill = drbrNarcissus, Width = 28.48692, Height = 49.99987, MaxWidth = 55.51219, MaxHeight = 97.4356 };
                    break;
                case enumDrawElement.ForgetMeNotStem:
                    elementToRender = new Rectangle { Fill = drbrForgetMeNotStem, Width = 32.87765, Height = 94.86762, MaxWidth = 64.06923, MaxHeight = 184.8702 };
                    break;
                case enumDrawElement.BlueBellStem:
                    elementToRender = new Rectangle { Fill = drbrBlueBellStem, Width = 26.58722, Height = 66.46805, MaxWidth = 51.81097, MaxHeight = 129.5274 };
                    break;
                case enumDrawElement.WhiteLilyStem:
                    elementToRender = new Rectangle { Fill = drbrWhiteLilyStem, Width = 158.7553, Height = 320.927, MaxWidth = 309.3692, MaxHeight = 625.5129 };
                    break;
                case enumDrawElement.RoseStem:
                    elementToRender = new Rectangle { Fill = drbrRoseStem, Width = 88.37713, Height = 86.55257, MaxWidth = 172.222, MaxHeight = 168.6665 };
                    break;
                case enumDrawElement.NarcissusStem:
                    elementToRender = new Rectangle { Fill = drbrNarcissusStem, Width = 43.73511, Height = 64.06603, MaxWidth = 85.22736, MaxHeight = 124.8466 };
                    break;
                case enumDrawElement.ForgetMeNotThreeStems:
                    elementToRender = new Rectangle { Fill = drbrForgetMeNotThreeStems, Width = 45.9185, Height = 115.7146, MaxWidth = 89.48217, MaxHeight = 225.4651 };
                    break;
                case enumDrawElement.BlueBellThreeStems:
                    elementToRender = new Rectangle { Fill = drbrBlueBellThreeStems, Width = 52.98178, Height = 116.1746, MaxWidth = 103.2465, MaxHeight = 226.3914 };
                    break;
                case enumDrawElement.WhiteLilyThreeStems:
                    elementToRender = new Rectangle { Fill = drbrWhiteLilyThreeStems, Width = 229.2489, Height = 321.5664, MaxWidth = 446.7412, MaxHeight = 626.642 };
                    break;
                case enumDrawElement.RoseThreeStems:
                    elementToRender = new Rectangle { Fill = drbrRoseThreeStems, Width = 136.6139, Height = 158.2806, MaxWidth = 266.2219, MaxHeight = 308.4441 };
                    break;
                case enumDrawElement.NarcissusThreeStems:
                    elementToRender = new Rectangle { Fill = drbrNarcissusThreeStems, Width = 52.60034, Height = 78.01398, MaxWidth = 102.5032, MaxHeight = 152.0272 };
                    break;
                case enumDrawElement.SimpleGrassApartSimple:
                    elementToRender = new Rectangle { Fill = drbrSimpleGrassApartSimple, Width = 16, Height = 20, MaxWidth = 62.35895, MaxHeight = 72.24099 };
                    break;
                case enumDrawElement.ShortGrassSimple:
                    elementToRender = new Rectangle { Fill = drbrShortGrassSimple, Width = 14, Height = 10, MaxWidth = 55.83074, MaxHeight = 40.63075 };
                    break;
                case enumDrawElement.SimpleGrassLinGradient:
                    elementToRender = new Rectangle { Fill = drbrSimpleGrassLinGradient, Width = 15, Height = 14, MaxWidth = 116.6307, MaxHeight = 88.76406 };
                    break;
                case enumDrawElement.SimpleGrass:
                    elementToRender = new Rectangle { Fill = drbrSimpleGrass, Width = 15, Height = 14, MaxWidth = 116.6307, MaxHeight = 88.76406 };
                    break;
                case enumDrawElement.SimpleGrassApart:
                    elementToRender = new Rectangle { Fill = drbrSimpleGrassApart, Width = 16, Height = 20, MaxWidth = 62.35895, MaxHeight = 72.24099 };
                    break;
                case enumDrawElement.ShortGrassDirty:
                    elementToRender = new Rectangle { Fill = drbrShortGrassDirty, Width = 15, Height = 14, MaxWidth = 55.83074, MaxHeight = 40.63075 };
                    break;
                case enumDrawElement.DirtyGreenGrass:
                    elementToRender = new Rectangle { Fill = drbrDirtyGreenGrass, Width = 15, Height = 14, MaxWidth = 116.6307, MaxHeight = 88.76406 };
                    break;
                default:
                    break;
            }

            // variable for rotating
            RotateTransform rtChosenElement = new RotateTransform();

            rtChosenElement.Angle = 0;
            rtChosenElement.CenterX = elementToRender.Width / 2;
            rtChosenElement.CenterY = elementToRender.Height / 2;
            elementToRender.RenderTransform = new RotateTransform(0, rtChosenElement.CenterX, rtChosenElement.CenterY); // this row for the possibility to rotate the shape later

            // Set top/left position to draw in the canvas.
            Canvas.SetLeft(elementToRender, e.GetPosition(canvasDrawingArea).X - rtChosenElement.CenterX);
            Canvas.SetTop(elementToRender, e.GetPosition(canvasDrawingArea).Y - rtChosenElement.CenterY);

            // Draw element!
            canvasDrawingArea.Children.Add(elementToRender);
        }

        private void canvasDrawingArea_MouseWheel(object sender, MouseWheelEventArgs e) // for rotating the chosen element
        {
            Rectangle rectChosenElement = null;

            // Firstly, get the X,Y location of where the user clicked.
            Point pt = e.GetPosition((Canvas)sender);
            // Use the HitTest() method of VisualTreeHelper to see if the user clicked on an item in the canvas.
            HitTestResult result = VisualTreeHelper.HitTest(canvasDrawingArea, pt);
            // If the result is not null, they DID click on a shape!
            try
            {
                if (e.Delta <= 0) // for rotating the chosen element
                {
                    if (result != null)
                    {
                        rectChosenElement = result.VisualHit as Rectangle;
                        if (rectChosenElement.MaxWidth == 16.10679 || rectChosenElement.MaxWidth == 40.92315 || rectChosenElement.MaxWidth == 175.3845 ||
                            rectChosenElement.MaxWidth == 126.6665 || rectChosenElement.MaxWidth == 55.51219)
                        {
                            //Rotating  clockwise
                            int indexOfElement = canvasDrawingArea.Children.IndexOf(rectChosenElement as Rectangle);
                            RotateTransform rt = canvasDrawingArea.Children[indexOfElement].RenderTransform as RotateTransform;
                            if (canvasDrawingArea.Children[indexOfElement].RenderTransform != null)
                            {
                                rt.Angle = (rt.Angle + 18) % 360;
                            }
                        }

                    }
                }
                else // for increasing the size
                {
                    if (result != null)
                    {
                        rectChosenElement = result.VisualHit as Rectangle;
                        //increasing by 10% up to 180
                        //rectChosenElement.RenderTransform = new RotateTransform(rtChosenElement.Angle, rtChosenElement.CenterX, rtChosenElement.CenterY);

                        if (rectChosenElement.Height * 1.1 < rectChosenElement.MaxHeight && rectChosenElement.Width * 1.1 < rectChosenElement.MaxWidth)
                        {
                            rectChosenElement.Height *= 1.1;
                            rectChosenElement.Width *= 1.1;
                            int indexOfElement = canvasDrawingArea.Children.IndexOf(rectChosenElement as Rectangle);
                            RotateTransform rt = canvasDrawingArea.Children[indexOfElement].RenderTransform as RotateTransform;
                            if (canvasDrawingArea.Children[indexOfElement].RenderTransform != null)
                            {
                                rt.CenterX = rectChosenElement.Width / 2;
                                rt.CenterY = rectChosenElement.Height / 2;
                                Canvas.SetLeft(rectChosenElement, e.GetPosition(canvasDrawingArea).X - rt.CenterX);
                                Canvas.SetTop(rectChosenElement, e.GetPosition(canvasDrawingArea).Y - rt.CenterY);
                            }

                        }

                    }
                }
            }
            catch (System.ArgumentOutOfRangeException)
            { }
            catch (System.NullReferenceException)
            {
                // USER MISTAKE 
            }
        }

        // A double click on the mouse right button for deleting the chosen element
        private void canvasDrawingArea_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Firstly, get the X,Y location of where the user clicked.
            Point pt = e.GetPosition((Canvas)sender);
            // Use the HitTest() method of VisualTreeHelper to see if the user clicked on an item in the canvas.
            HitTestResult result = VisualTreeHelper.HitTest(canvasDrawingArea, pt);

            if (e.ClickCount > 1) // delete the shosen shape
            {
                if (result != null)
                {
                    // Get the underlying shape clicked on, and remove it from the canvas.
                    canvasDrawingArea.Children.Remove(result.VisualHit as Shape);
                    moving = false;
                }

            }
            else //e.ClickCount = 1
            {
                rectChosenElementForMoving = result.VisualHit as Rectangle;
                if (rectChosenElementForMoving != null)
                {
                    moving = true;
                    rectChosenElementForMoving.CaptureMouse();
                }
            }
            e.Handled = true;

        }

        private void canvasDrawingArea_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Point pt = e.GetPosition((Canvas)sender);
            HitTestResult result = VisualTreeHelper.HitTest(canvasDrawingArea, pt);

            if (result != null)
            {
                //Rectangle rectChosenElementForMoving = result.VisualHit as Rectangle;
                if (rectChosenElementForMoving != null)
                {
                    rectChosenElementForMoving.ReleaseMouseCapture();
                    moving = false;
                }

            }
        }

        private void canvasDrawingArea_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving && e.RightButton == MouseButtonState.Pressed)
            {
                Canvas.SetLeft(rectChosenElementForMoving, e.GetPosition(canvasDrawingArea).X - rectChosenElementForMoving.Width * 0.5);
                Canvas.SetTop(rectChosenElementForMoving, e.GetPosition(canvasDrawingArea).Y - rectChosenElementForMoving.Height * 0.5);
            }
            e.Handled = true;
        }


    }
}

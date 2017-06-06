using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UNIVERSALTEST
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {

		public ObservableCollection<int> Degrees = new ObservableCollection<int>
		{
			0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30
		};
		private int selectedDegrees = 0;
		public int SelectedDegrees
		{
			get { return selectedDegrees; }
			set { selectedDegrees = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedDegrees))); }
		}


		public ObservableCollection<int> Minutes = new ObservableCollection<int>
		{
			0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30
		};
		private int selectedMinutes = 0;
		public int SelectedMinutes
		{
			get { return selectedMinutes; }
			set { selectedMinutes = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedMinutes))); }
		}


		public ObservableCollection<int> Seconds = new ObservableCollection<int>
		{
			0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30
		};

		private int selectedSeconds = 0;
		public int SelectedSeconds
		{
			get { return selectedSeconds; }
			set { selectedSeconds = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedSeconds))); }
		}
		public ObservableCollection<int> Hundredth = new ObservableCollection<int>
		{
			0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30
		};
		private int selectedHundredth = 0;
		public int SelectedHundredth
		{
			get { return selectedHundredth; }
			set { selectedHundredth = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedHundredth))); }
		}

		public event PropertyChangedEventHandler PropertyChanged;


		public MainPage()
        {
            this.InitializeComponent();
        }

		private async void Flyout_Opened(object sender, object e)
		{
			await Task.Delay(100);
			Debug.WriteLine("Open");
			SelectedDegrees = 5;
			SelectedMinutes = 5;
			SelectedSeconds = 5;
			SelectedHundredth = 5;
		}
	}
}

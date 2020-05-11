using System.Windows.Controls;
using System.ComponentModel;
using System.Windows.Input;
using LinkedListWPFSimulator.Commands;
using System.Windows;
using System.Collections.ObjectModel;

namespace LinkedListWPFSimulator.ViewModels
{
    public class LinkedListViewModel : INotifyPropertyChanged
	{
		//constructor
		public LinkedListViewModel()
		{
			PushNewHead = new DelegateCommands(PushNewHeadExecute);
			AddNode = new DelegateCommands(AddNodeExecute);
			RemoveNode = new DelegateCommands(RemoveNodeExecute);
			ChangeValue = new DelegateCommands(ChangeValueExecute);
		}

		

		// fields
		public string Title { get; private set; } = "Linked List Simulator";
		
		private string _headNode;
		public string HeadNode
		{
			get { return _headNode; }
			set 
			{ 
				_headNode = value;
				OnPropertyChanged("HeadNode");
			}
		}

		public ObservableCollection<ObservableCollection<Button>> ListofLinkedLists { get; set; } = new ObservableCollection<ObservableCollection<Button>>();
		public ObservableCollection<Button> LinkedList { get; set; } = new ObservableCollection<Button>();

		//Commands
		public ICommand PushNewHead { get; set; }



		//INotifyPropertyChanged
		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged(string propName)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propName));
		}

		//Make Command functions

		public ICommand AddNode { get; set; }

		private void AddNodeExecute(object obj)
		{
			MessageBox.Show("Add node");
		}

		public ICommand RemoveNode { get; set; }

		private void RemoveNodeExecute(object obj)
		{
			MessageBox.Show("Remove node");
		}

		public ICommand ChangeValue { get; set; }

		private void ChangeValueExecute(object obj)
		{
			MessageBox.Show("Change node value");
		}

		private void PushNewHeadExecute(object obj)
		{
			Button btn = new Button();
			btn.Content = HeadNode;
			btn.MinHeight = 50;
			btn.MinWidth = 50;
			btn.Margin = new Thickness(0);

			btn.ContextMenu = AddContextMenu();

			LinkedList.Add(btn);
			ListBox HeadofLinkList = new ListBox();
			HeadofLinkList.ItemsSource = LinkedList;

			ListofLinkedLists.Add(LinkedList);
			ListBox ListofLists = new ListBox();
			ListofLists.ItemsSource = ListofLinkedLists;

			
		}

		//helper functions
		private ContextMenu AddContextMenu()
		{
			ContextMenu cm = new ContextMenu();

			MenuItem add = new MenuItem();
			add.Header = "Add";
			add.Command = AddNode;

			MenuItem rem = new MenuItem();
			rem.Header = "Remove";
			rem.Command = RemoveNode;

			MenuItem chv = new MenuItem();
			chv.Header = "Change Value";
			chv.Command = ChangeValue;

			cm.Items.Add(add);
			cm.Items.Add(rem);
			cm.Items.Add(chv);

			return cm;
		}

	}
}

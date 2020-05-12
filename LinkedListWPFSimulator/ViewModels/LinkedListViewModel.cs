using System.Windows.Controls;
using System.ComponentModel;
using System.Windows.Input;
using LinkedListWPFSimulator.Commands;
using System.Windows;
using System.Collections.ObjectModel;
using System;

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

		public ObservableCollection<ListBox> ListofLinkedLists { get; set; } = new ObservableCollection<ListBox>();
		public ObservableCollection<Button> LinkedList { get; set; }

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
			System.Console.WriteLine(obj.ToString());

			foreach(ListBox lists in ListofLinkedLists)
			{
				foreach(Button btn in lists.CommandBindings)
				{
					if (btn.CommandParameter.Equals(obj.ToString()))
					{
						Console.WriteLine(LinkedList.IndexOf(btn));
					}
					else
					{
						Console.WriteLine();
					}
				}
			}

		}

		public ICommand RemoveNode { get; set; }

		private void RemoveNodeExecute(object obj)
		{
			MessageBox.Show("Remove node");
			System.Console.WriteLine(obj.ToString());
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

			LinkedList = new ObservableCollection<Button>();

			LinkedList.Add(btn);
			ListBox HeadofLinkList = new ListBox();
			HeadofLinkList.ItemsSource = LinkedList;

			ListofLinkedLists.Add(HeadofLinkList);
		}

		//helper functions
		private int nodeAddress = 0;
		private ContextMenu AddContextMenu()
		{
			ContextMenu cm = new ContextMenu();

			MenuItem add = new MenuItem();
			add.Header = "Add";
			add.Command = AddNode;
			add.CommandParameter = "Add" + Convert.ToString(++nodeAddress);
			add.Tag = "Add" + Convert.ToString(++nodeAddress);

			MenuItem rem = new MenuItem();
			rem.Header = "Remove";
			rem.Command = RemoveNode;
			rem.CommandParameter = "Remove" + Convert.ToString(++nodeAddress);
			rem.Tag = "Remove" + Convert.ToString(++nodeAddress);

			MenuItem chv = new MenuItem();
			chv.Header = "Change Value";
			chv.Command = ChangeValue;
			chv.CommandParameter = "Change Value" + Convert.ToString(++nodeAddress);
			chv.Tag = "Change Value" + Convert.ToString(++nodeAddress);

			cm.Items.Add(add);
			cm.Items.Add(rem);
			cm.Items.Add(chv);

			return cm;
		}

		private Button CreateNode()
		{
			Button btn = new Button();
			btn.Content = HeadNode;
			btn.MinHeight = 50;
			btn.MinWidth = 50;
			btn.Margin = new Thickness(0);

			btn.ContextMenu = AddContextMenu();
			return btn;
		}

	}
}

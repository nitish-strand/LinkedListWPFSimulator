using System.Windows.Controls;
using System.ComponentModel;
using System.Windows.Input;
using LinkedListWPFSimulator.Commands;
using System.Windows;
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Xaml;

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

			foreach (ListBox lists in ListofLinkedLists)
			{
				LinkedList = new ObservableCollection<Button>();
				foreach (Button btn in lists.ItemsSource)
				{
					LinkedList.Add(btn);
					if (btn.Name.Equals(obj.ToString()))
					{
						LinkedList.Add(CreateNode("NewNode"));
						//lists.ItemsSource.Add(CreateNode("NewNode"));
					}
				}
				lists.ItemsSource = LinkedList;
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

		private int nodeAddress = 0;
		private void PushNewHeadExecute(object obj)
		{
			++nodeAddress;
			string nodeAddressStr = "Node" + Convert.ToString(nodeAddress);

			Button btn = new Button();
			btn.Content = HeadNode;
			btn.MinHeight = 50;
			btn.MinWidth = 50;
			btn.Margin = new Thickness(0);
			btn.Name = nodeAddressStr;

			btn.ContextMenu = AddContextMenu(nodeAddressStr);

			LinkedList = new ObservableCollection<Button>();

			LinkedList.Add(btn);
			ListBox HeadofLinkList = new ListBox();
			HeadofLinkList.ItemsSource = LinkedList;
			
			var nw = new FrameworkElementFactory(typeof(WrapPanel));

			ItemsPanelTemplate panelTemp = new ItemsPanelTemplate();
			panelTemp.VisualTree = nw;

			HeadofLinkList.ItemsPanel = panelTemp;
			ListofLinkedLists.Add(HeadofLinkList);
		}

		//helper functions

		private ContextMenu AddContextMenu(string nodeAddessstr)
		{
			
			ContextMenu cm = new ContextMenu();

			MenuItem add = new MenuItem();
			add.Header = "Add";
			add.Command = AddNode;
			add.CommandParameter = nodeAddessstr;

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

		private Button CreateNode(string NodeValue)
		{
			++nodeAddress;
			string nodeAddressStr = "Node" + Convert.ToString(nodeAddress);

			Button btn = new Button();
			btn.Content = NodeValue;
			btn.MinHeight = 50;
			btn.MinWidth = 50;
			btn.Margin = new Thickness(0);
			btn.Name = nodeAddressStr;

			btn.ContextMenu = AddContextMenu(nodeAddressStr);
			return btn;
		}

	}
}

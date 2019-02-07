﻿using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace DHDM
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		ScrollPage activePage = ScrollPage.main;
		public MainWindow()
		{
			InitializeComponent();
			FocusHelper.FocusedControlsChanged += FocusHelper_FocusedControlsChanged;
		}

		public int PlayerID
		{
			get
			{
				return tabPlayers.SelectedIndex;
			}
		}

		private void FocusHelper_FocusedControlsChanged(object sender, FocusedControlsChangedEventArgs e)
		{
			foreach (StatBox statBox in e.Active)
			{
				HubtasticBaseStation.FocusItem(PlayerID, activePage, statBox.FocusItem);
			}

			foreach (StatBox statBox in e.Deactivated)
			{
				HubtasticBaseStation.UnfocusItem(PlayerID, activePage, statBox.FocusItem);
			}
		}

		private void TabControl_PlayerChanged(object sender, SelectionChangedEventArgs e)
		{
			activePage = ScrollPage.main;
			FocusHelper.ClearActiveStatBoxes();
			HubtasticBaseStation.PlayerPageChanged(PlayerID, activePage, string.Empty);
		}

		void ConnectToHub()
		{
			
		}

		private void CharacterSheets_PageChanged(object sender, RoutedEventArgs ea)
		{
			if (sender is CharacterSheets characterSheets && activePage != characterSheets.Page)
			{
				activePage = characterSheets.Page;
				HubtasticBaseStation.PlayerPageChanged(tabPlayers.SelectedIndex, activePage, string.Empty);
			}
		}

		private void btnSampleEffect_Click(object sender, RoutedEventArgs e)
		{
			AnimationEffect animationEffect = new AnimationEffect("DenseSmoke", new VisualEffectTarget(960, 1080), 0, 220, 100, 100);
			string serializedObject = JsonConvert.SerializeObject(animationEffect);
			HubtasticBaseStation.TriggerEffect(serializedObject);
		}
	}
}

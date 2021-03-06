﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Parse;
using System.Threading.Tasks;

namespace OfficialVitruvianApp
{
	public class AddTeamPage:ContentPage
	{
		ParseObject data;

		public AddTeamPage (ParseObject teamData)
		{
			Label teamNumberLabel = new Label () {
				Text = "Team Number:"
			};

			Entry teamNumber = new Entry ();
			try {
				if (teamData ["teamNumber"] != null) {
					teamNumber.Text = teamData ["teamNumber"].ToString();
				} else {}
			}
			catch {
				teamNumber.Placeholder = "Enter Team Number";
			}

			teamNumber.Keyboard = Keyboard.Numeric;

			Label teamNameLabel = new Label () {
				Text = "Team Name:"
			};

			Entry teamName = new Entry ();
			try {
				if (teamData ["teamName"] != null) {
					teamName.Text = teamData ["teamName"].ToString();
				} else {} 
			} catch {
				teamName.Placeholder = "Enter Team Name";
			}

			Label teamTypeLabel = new Label () {
				Text = "Type:"
			};

			Entry teamType = new Entry ();
			try {
				if (teamData ["teamType"] != null) {
					teamType.Text = teamData ["teamType"].ToString();
				} else {}
			} catch {
				teamType.Placeholder = "Enter Team Type";
			}

			data = teamData;

			Button updateBtn = new Button(){Text = "Update"};
			updateBtn.Clicked += (object sender, EventArgs e) => {
				data ["teamNumber"] = int.Parse(teamNumber.Text);
				data ["teamName"] = teamName.Text;
				data ["teamType"] = teamType.Text;
				SaveData ();
			};

			ScrollView scrollView = new ScrollView ();
			scrollView.HorizontalOptions = LayoutOptions.FillAndExpand;
			scrollView.VerticalOptions = LayoutOptions.FillAndExpand;
			scrollView.Content = new StackLayout () {

				Children = {
					teamNumberLabel,
					teamNumber,
					teamNameLabel,
					teamName,
					teamTypeLabel,
					teamType,
					updateBtn
				}
			};

			Content = scrollView;
		}
		async void SaveData(){
			Console.WriteLine ("Saving...");
			await data.SaveAsync ();
			Console.WriteLine ("Done Saving");
			Navigation.PopModalAsync ();
		}
	}
}


using System;
using Microsoft.Maui.Controls;

namespace pmu1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            // Event handler for Picker selection change
            ModePicker.SelectedIndexChanged += ModePicker_SelectedIndexChanged;
        }

        private void ModePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            HydrostaticPressureLayout.IsVisible = ModePicker.SelectedIndex == 0;
            MachineEfficiencyLayout.IsVisible = ModePicker.SelectedIndex == 1;

            // Clear previous results when switching modes
            PressureResultLabel.Text = string.Empty;
            EfficiencyResultLabel.Text = string.Empty;
        }

        private void CalculatePressureButton_Clicked(object sender, EventArgs e)
        {
            if (double.TryParse(DensityEntry.Text, out double density) &&
                double.TryParse(DepthEntry.Text, out double depth))
            {
                const double g = 9.81; // Gravitational constant
                double pressure = density * g * depth;
                PressureResultLabel.Text = $"Hidrostatski tlak: {pressure:F2} Pa";
            }
            else
            {
                PressureResultLabel.Text = "Molimo unesite ispravne vrijednosti.";
            }
        }

        private void CalculateEfficiencyButton_Clicked(object sender, EventArgs e)
        {
            if (double.TryParse(InputWorkEntry.Text, out double workIn) &&
                double.TryParse(OutputWorkEntry.Text, out double workOut) && workIn != 0)
            {
                double efficiency = (workOut / workIn) * 100;
                EfficiencyResultLabel.Text = $"Efikasnost: {efficiency:F2} %";
            }
            else
            {
                EfficiencyResultLabel.Text = "Molimo unesite ispravne vrijednosti.";
            }
        }
    }
}

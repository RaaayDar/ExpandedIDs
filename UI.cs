using System.Collections.Generic;
using BepInEx.Logging;
using Menu.Remix.MixedUI;
using Menu.Remix.MixedUI.ValueTypes;

namespace BiggerID
{

    internal class UI : OptionInterface
    {
        private readonly ManualLogSource logger;
        public UI(Hooks modInstance, ManualLogSource loggerSource)
        {
            this.logger = loggerSource;

            ScavIDOne = config.Bind<int>("RaaayDar_ScavIds=One", 0, new ConfigurableInfo("Sets the starting int for Scavengers."));
            ScavIDTwo = config.Bind<int>("RaaayDar_ScavIds=Two", 0, new ConfigurableInfo("Sets the ending int for Scavengers."));
        }

        public readonly Configurable<int> ScavIDOne;
        public readonly Configurable<int> ScavIDTwo;

        private OpLabel scavIdLabelOne;
        //private OpLabel scavIdLabelTwo;
        private OpTextBox ScavIDinputOne;
        // private OpTextBox ScavIDinputtwo;

        public override void Initialize()
        {
            base.Initialize();

            // Initialize tab
            var opTab = new OpTab(this, "Options");
            this.Tabs = new[]
            {
                opTab
            };

            scavIdLabelOne = new OpLabel(40f, 410f, "Scav id");
            //scavIdLabelTwo = new OpLabel(40f, 410f, "Scav id");


            opTab.AddItems(
                new OpLabel(10f, 560f, "OPTIONS", true),
                new OpLabel(40f, 440f, "Scavs use specific id (can cause glitches)"),
                    scavIdLabelOne,
                    ScavIDinputOne
                    );
        }

        public override void Update()
        {
            base.Update();

            scavIdLabelOne.Show();
            ScavIDinputOne?.Show();


        }
    }
}


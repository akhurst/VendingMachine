﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachine.Menu.SodaMenu;

namespace VendingMachine.Test
{
    [TestClass]
    public class AddingMoney
    {
        private SodaMachine machine;
        private SodaMachineUi ui;

        [TestInitialize]
        public void SetUp()
        {
            machine = new SodaMachine(10);
            ui = new SodaMachineUi(machine);
        }

        [TestMethod]
        public void ShouldUpdateCustomerBalance()
        {
            ui.PerformAction(MainMenu.Commands.AddMoney + " " + "1.25");

            Assert.AreEqual(1.25, machine.CustomerBalance);
        }

        [TestMethod]
        public void ShouldIgnoreInvalidAmount()
        {
            ui.PerformAction(MainMenu.Commands.AddMoney + " abc");

            AssertIsAtMainMenu();
            Assert.AreEqual(0, machine.CustomerBalance);
        }

        [TestMethod]
        public void ShouldIgnoreNoAmount()
        {
            ui.PerformAction(MainMenu.Commands.AddMoney.Commands[0]);

            AssertIsAtMainMenu();
            Assert.AreEqual(0, machine.CustomerBalance);
        }

        [TestMethod]
        public void ShouldIgnoreNegativeAmount()
        {
            ui.PerformAction(MainMenu.Commands.AddMoney + " -.25");

            Assert.AreEqual(0, machine.CustomerBalance);
        }

        [TestMethod]
        public void ShouldIgnoreInputWithMoreThan2DecimalPlaces()
        {
            ui.PerformAction(MainMenu.Commands.AddMoney + " .244");

            Assert.AreEqual(0, machine.CustomerBalance);
        }

        private void AssertIsAtMainMenu()
        {
            Assert.IsInstanceOfType(ui.TopViewController, typeof(MainMenu));
        }
    }
}

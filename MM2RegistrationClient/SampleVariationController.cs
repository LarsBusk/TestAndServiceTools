using log4net;
using OPCClient.Communicators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;

namespace RegistrationClient
{
    class SampleVariationController : INotifyPropertyChanged
    {

        #region public properties

        public bool Registration2First
        {
            get => registration2First;

            set
            {
                registration2First = value;
                NotifyPropertyChanged();
            }
        }


        public bool NoReadOnRfid
        {
            get => noReadOnRfid;

            set
            {
                noReadOnRfid = value;
                NotifyPropertyChanged();
            }
        }

        public bool NoValues
        {
            get => noValues;

            set
            {
                noValues = value;
                NotifyPropertyChanged();
            }
        }

        public bool TooGreatTimeDifference
        {
            get => tooGreatTimeDifference;

            set
            {
                tooGreatTimeDifference = value;
                NotifyPropertyChanged();
            }
        }

        public bool DoubleValues
        {
            get => doubleValues;

            set
            {
                doubleValues = value;
                NotifyPropertyChanged();
            }
        }

        public bool OnlyValue1
        {
            get => onlyValue1;

            set
            {
                onlyValue1 = value;
                NotifyPropertyChanged();
            }
        }

        public int RegValueToSkip
        {
            get => regValueToSkip;

            set
            {
                regValueToSkip = value;
                NotifyPropertyChanged();
            }
        }

        public int RegValueToDouble
        {
            get => regValueToDouble;

            set
            {
                regValueToDouble = value;
                NotifyPropertyChanged();
            }
        }

        public bool IsDelayed
        {
            get => isDelayed;

            set
            {
                isDelayed = value;
                NotifyPropertyChanged();
                ActualDelay = DelayStartValue;
            }
        }

        public int ActualDelay
        {
            get => actualDelay;

            set
            {
                actualDelay = value;
                NotifyPropertyChanged();
            }
        }

        public int DelayIncrease
        {
            get => delayIncrease;

            set
            {
                delayIncrease = value;
                NotifyPropertyChanged();
            }
        }

        public int DelayStartValue
        {
            get => delayStartValue;

            set
            {
                delayStartValue = value;
                NotifyPropertyChanged();
            }
        }

        public int DelayEndValue
        {
            get => delayEndValue;

            set
            {
                delayEndValue = value;
                NotifyPropertyChanged();
            }
        }

        public bool IsKepServer;

        public List<int> SampleIds { get; set; }

        public List<int> ProductCodes;

        #endregion

        #region private fields

        private bool registration2First;

        private bool isDelayed;

        private bool noReadOnRfid;

        private bool noValues;

        private bool tooGreatTimeDifference;

        private bool doubleValues;

        private bool onlyValue1;

        private int actualDelay;

        private int delayStartValue;

        private int delayEndValue;

        private int delayIncrease;

        private int reg2Value = 0;

        private int reg1Value = 0;

        private int boxReg1Counter = 0;

        private int boxProductCodeCounter = 0;

        private int skipPercentage = 20;

        private int regValueToSkip;

        private int regValueToDouble;

        private int productCode;

        private readonly ILog log = LogManager.GetLogger(typeof(SampleVariationController));

        #endregion



        #region Public methods

        public SampleVariationController()
        {
            this.DoubleValues = false;
            this.NoReadOnRfid = false;
            this.NoValues = false;
            this.Registration2First = false;
            this.TooGreatTimeDifference = false;
            this.OnlyValue1 = false;
        }

        public bool WriteProductCodeN(int productCode)
        {
            if (IsDelayed)
            {
                log.Debug($"Before delay {ActualDelay}");

                new Thread(() =>
                {
                    Thread.Sleep(ActualDelay);
                    SetProductCode(productCode);
                }).Start();

                ActualDelay += DelayIncrease;

                if (ActualDelay > DelayEndValue) ActualDelay = DelayStartValue;

                return true;
            }

            SetProductCode(productCode);
            return true;
        }

        public void WriteRegistrationValuesToPDxTags()
        {
            var timeDifference = TooGreatTimeDifference ? 1500 : 25;

            if (!SkipValue(noValues)) return;

            if (registration2First)
            {
                WriteReg2();
                Thread.Sleep(timeDifference);
                WriteReg1();
            }
            else
            {
                WriteReg1();
                Thread.Sleep(timeDifference);
                WriteReg2();
            }
        }

        public void WriteRegistrationValuesToOpcServer()
        {
            var timeDifference = TooGreatTimeDifference ? 1500 : 25;

            MeatMasterOPCCommunicatior.SetPreRegistrationsValue1(reg1Value);
            Thread.Sleep(timeDifference);
            MeatMasterOPCCommunicatior.SetPreRegistrationsValue2(reg2Value);
        }

        #endregion



        private void WriteReg1()
        {
            if (SkipValue(noReadOnRfid) && regValueToSkip == 1) return;

            MeatMasterOPCCommunicatior.KepServerSetRegistrationValue1(reg1Value);

            if (SkipValue(doubleValues) && RegValueToDouble == 1)
            {
                Thread.Sleep(500);
                MeatMasterOPCCommunicatior.KepServerSetRegistrationValue1(reg1Value);
            }
        }

        private void WriteReg2()
        {
            if (OnlyValue1) return;

            if (SkipValue(noReadOnRfid) && regValueToSkip == 2) return;

            MeatMasterOPCCommunicatior.KepServerSetRegistrationValue2(reg2Value);

            if (SkipValue(doubleValues) && RegValueToDouble == 2)
            {
                Thread.Sleep(500);
                MeatMasterOPCCommunicatior.KepServerSetRegistrationValue2(reg2Value);
            }
        }



        private void SetProductCode(int productCode)
        {
            if (IsKepServer)
            {
                MeatMasterOPCCommunicatior.KepServerSetProductCodeN(productCode);
            }
            else
            {
                MeatMasterOPCCommunicatior.ChangeProduct(productCode);
            }
        }

        private void SetRegistrationValuesFromBoxes()
        {
            reg1Value = SampleIds[boxReg1Counter];

            reg2Value++;

            boxReg1Counter++;
            if (boxReg1Counter >= SampleIds.Count)
            {
                boxReg1Counter = 0;
            }
        }

        private void GetProductCodeFromBoxes()
        {
            productCode = ProductCodes[boxProductCodeCounter];

            boxProductCodeCounter++;

            if (boxProductCodeCounter >= ProductCodes.Count)
            {
                boxProductCodeCounter = 0;
            }
        }

        private bool SkipValue(bool skip)
        {
            if (!skip) return false;

            var random = new Random();
            return random.Next(100) < skipPercentage;
        }

        #region Implement INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        internal RegistrationValues GetValuesFromBoxes()
        {
            SetRegistrationValuesFromBoxes();
            GetProductCodeFromBoxes();
            return new RegistrationValues
            {
                RegValue1 = reg1Value,
                RegValue2 = reg2Value,
                ProductCode = productCode
            };
        }

        internal RegistrationValues GetRandomValues()
        {
            Random random = new Random();
            reg1Value = random.Next(10000);
            reg2Value = random.Next(10000);
            productCode = ProductCodes[random.Next(ProductCodes.Count)];

            return new RegistrationValues
            {
                RegValue1 = reg1Value,
                RegValue2 = reg2Value,
                ProductCode = productCode
            };
        }
    }

    public struct RegistrationValues
    {
        public int RegValue1;
        public int RegValue2;
        public int ProductCode;
    }
}

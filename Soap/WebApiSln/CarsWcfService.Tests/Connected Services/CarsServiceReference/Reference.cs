﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarsWcfService.Tests.CarsServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Car", Namespace="http://schemas.datacontract.org/2004/07/CarsWcfService")]
    [System.SerializableAttribute()]
    public partial class Car : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PlacesField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Places {
            get {
                return this.PlacesField;
            }
            set {
                if ((this.PlacesField.Equals(value) != true)) {
                    this.PlacesField = value;
                    this.RaisePropertyChanged("Places");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CarsServiceReference.ICarsService")]
    public interface ICarsService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICarsService/AddCar", ReplyAction="http://tempuri.org/ICarsService/AddCarResponse")]
        bool AddCar(CarsWcfService.Tests.CarsServiceReference.Car car);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICarsService/AddCar", ReplyAction="http://tempuri.org/ICarsService/AddCarResponse")]
        System.Threading.Tasks.Task<bool> AddCarAsync(CarsWcfService.Tests.CarsServiceReference.Car car);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICarsService/GetCars", ReplyAction="http://tempuri.org/ICarsService/GetCarsResponse")]
        CarsWcfService.Tests.CarsServiceReference.Car[] GetCars();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICarsService/GetCars", ReplyAction="http://tempuri.org/ICarsService/GetCarsResponse")]
        System.Threading.Tasks.Task<CarsWcfService.Tests.CarsServiceReference.Car[]> GetCarsAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICarsServiceChannel : CarsWcfService.Tests.CarsServiceReference.ICarsService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CarsServiceClient : System.ServiceModel.ClientBase<CarsWcfService.Tests.CarsServiceReference.ICarsService>, CarsWcfService.Tests.CarsServiceReference.ICarsService {
        
        public CarsServiceClient() {
        }
        
        public CarsServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CarsServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CarsServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CarsServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool AddCar(CarsWcfService.Tests.CarsServiceReference.Car car) {
            return base.Channel.AddCar(car);
        }
        
        public System.Threading.Tasks.Task<bool> AddCarAsync(CarsWcfService.Tests.CarsServiceReference.Car car) {
            return base.Channel.AddCarAsync(car);
        }
        
        public CarsWcfService.Tests.CarsServiceReference.Car[] GetCars() {
            return base.Channel.GetCars();
        }
        
        public System.Threading.Tasks.Task<CarsWcfService.Tests.CarsServiceReference.Car[]> GetCarsAsync() {
            return base.Channel.GetCarsAsync();
        }
    }
}

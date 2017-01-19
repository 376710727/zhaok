﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Z.Framework.WorkBench.zService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CompositeType", Namespace="http://schemas.datacontract.org/2004/07/Z.Framework.Service")]
    [System.SerializableAttribute()]
    public partial class CompositeType : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool BoolValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StringValueField;
        
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
        public bool BoolValue {
            get {
                return this.BoolValueField;
            }
            set {
                if ((this.BoolValueField.Equals(value) != true)) {
                    this.BoolValueField = value;
                    this.RaisePropertyChanged("BoolValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StringValue {
            get {
                return this.StringValueField;
            }
            set {
                if ((object.ReferenceEquals(this.StringValueField, value) != true)) {
                    this.StringValueField = value;
                    this.RaisePropertyChanged("StringValue");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="zService.IService")]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetData", ReplyAction="http://tempuri.org/IService/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetData", ReplyAction="http://tempuri.org/IService/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService/GetDataUsingDataContractResponse")]
        Z.Framework.WorkBench.zService.CompositeType GetDataUsingDataContract(Z.Framework.WorkBench.zService.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<Z.Framework.WorkBench.zService.CompositeType> GetDataUsingDataContractAsync(Z.Framework.WorkBench.zService.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetConnection", ReplyAction="http://tempuri.org/IService/GetConnectionResponse")]
        bool GetConnection(string ip);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetConnection", ReplyAction="http://tempuri.org/IService/GetConnectionResponse")]
        System.Threading.Tasks.Task<bool> GetConnectionAsync(string ip);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/LoginByPassword", ReplyAction="http://tempuri.org/IService/LoginByPasswordResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Z.Framework.WorkBench.zService.CompositeType))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Collections.Generic.KeyValuePair<object, object>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Z.Framework.Model.Account_Info))]
        Z.Framework.Common.ResultInfo LoginByPassword(Z.Framework.Model.Account_Info user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/LoginByPassword", ReplyAction="http://tempuri.org/IService/LoginByPasswordResponse")]
        System.Threading.Tasks.Task<Z.Framework.Common.ResultInfo> LoginByPasswordAsync(Z.Framework.Model.Account_Info user);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : Z.Framework.WorkBench.zService.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<Z.Framework.WorkBench.zService.IService>, Z.Framework.WorkBench.zService.IService {
        
        public ServiceClient() {
        }
        
        public ServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value) {
            return base.Channel.GetDataAsync(value);
        }
        
        public Z.Framework.WorkBench.zService.CompositeType GetDataUsingDataContract(Z.Framework.WorkBench.zService.CompositeType composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        public System.Threading.Tasks.Task<Z.Framework.WorkBench.zService.CompositeType> GetDataUsingDataContractAsync(Z.Framework.WorkBench.zService.CompositeType composite) {
            return base.Channel.GetDataUsingDataContractAsync(composite);
        }
        
        public bool GetConnection(string ip) {
            return base.Channel.GetConnection(ip);
        }
        
        public System.Threading.Tasks.Task<bool> GetConnectionAsync(string ip) {
            return base.Channel.GetConnectionAsync(ip);
        }
        
        public Z.Framework.Common.ResultInfo LoginByPassword(Z.Framework.Model.Account_Info user) {
            return base.Channel.LoginByPassword(user);
        }
        
        public System.Threading.Tasks.Task<Z.Framework.Common.ResultInfo> LoginByPasswordAsync(Z.Framework.Model.Account_Info user) {
            return base.Channel.LoginByPasswordAsync(user);
        }
    }
}

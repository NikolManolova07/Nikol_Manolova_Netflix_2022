﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NF.Website.MoviesReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MovieDto", Namespace="http://schemas.datacontract.org/2004/07/NF.ApplicationServices.DTOs")]
    [System.SerializableAttribute()]
    public partial class MovieDto : NF.Website.MoviesReference.BaseDto {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private NF.Website.MoviesReference.DirectorDto DirectorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private NF.Website.MoviesReference.GenreDto GenreField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MovieInfoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private NF.Website.MoviesReference.ProducerDto ProducerField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private NF.Website.MoviesReference.RatingDto RatingField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ReleaseCountryField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> ReleaseDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TitleField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public NF.Website.MoviesReference.DirectorDto Director {
            get {
                return this.DirectorField;
            }
            set {
                if ((object.ReferenceEquals(this.DirectorField, value) != true)) {
                    this.DirectorField = value;
                    this.RaisePropertyChanged("Director");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public NF.Website.MoviesReference.GenreDto Genre {
            get {
                return this.GenreField;
            }
            set {
                if ((object.ReferenceEquals(this.GenreField, value) != true)) {
                    this.GenreField = value;
                    this.RaisePropertyChanged("Genre");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MovieInfo {
            get {
                return this.MovieInfoField;
            }
            set {
                if ((object.ReferenceEquals(this.MovieInfoField, value) != true)) {
                    this.MovieInfoField = value;
                    this.RaisePropertyChanged("MovieInfo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public NF.Website.MoviesReference.ProducerDto Producer {
            get {
                return this.ProducerField;
            }
            set {
                if ((object.ReferenceEquals(this.ProducerField, value) != true)) {
                    this.ProducerField = value;
                    this.RaisePropertyChanged("Producer");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public NF.Website.MoviesReference.RatingDto Rating {
            get {
                return this.RatingField;
            }
            set {
                if ((object.ReferenceEquals(this.RatingField, value) != true)) {
                    this.RatingField = value;
                    this.RaisePropertyChanged("Rating");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ReleaseCountry {
            get {
                return this.ReleaseCountryField;
            }
            set {
                if ((object.ReferenceEquals(this.ReleaseCountryField, value) != true)) {
                    this.ReleaseCountryField = value;
                    this.RaisePropertyChanged("ReleaseCountry");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> ReleaseDate {
            get {
                return this.ReleaseDateField;
            }
            set {
                if ((this.ReleaseDateField.Equals(value) != true)) {
                    this.ReleaseDateField = value;
                    this.RaisePropertyChanged("ReleaseDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Title {
            get {
                return this.TitleField;
            }
            set {
                if ((object.ReferenceEquals(this.TitleField, value) != true)) {
                    this.TitleField = value;
                    this.RaisePropertyChanged("Title");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BaseDto", Namespace="http://schemas.datacontract.org/2004/07/NF.ApplicationServices.DTOs")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(NF.Website.MoviesReference.DirectorDto))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(NF.Website.MoviesReference.GenreDto))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(NF.Website.MoviesReference.ProducerDto))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(NF.Website.MoviesReference.RatingDto))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(NF.Website.MoviesReference.MovieDto))]
    public partial class BaseDto : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
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
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DirectorDto", Namespace="http://schemas.datacontract.org/2004/07/NF.ApplicationServices.DTOs")]
    [System.SerializableAttribute()]
    public partial class DirectorDto : NF.Website.MoviesReference.BaseDto {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DirectorInfoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FirstNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LastNameField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DirectorInfo {
            get {
                return this.DirectorInfoField;
            }
            set {
                if ((object.ReferenceEquals(this.DirectorInfoField, value) != true)) {
                    this.DirectorInfoField = value;
                    this.RaisePropertyChanged("DirectorInfo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FirstName {
            get {
                return this.FirstNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FirstNameField, value) != true)) {
                    this.FirstNameField = value;
                    this.RaisePropertyChanged("FirstName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LastName {
            get {
                return this.LastNameField;
            }
            set {
                if ((object.ReferenceEquals(this.LastNameField, value) != true)) {
                    this.LastNameField = value;
                    this.RaisePropertyChanged("LastName");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="GenreDto", Namespace="http://schemas.datacontract.org/2004/07/NF.ApplicationServices.DTOs")]
    [System.SerializableAttribute()]
    public partial class GenreDto : NF.Website.MoviesReference.BaseDto {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string GenreInfoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string GenreInfo {
            get {
                return this.GenreInfoField;
            }
            set {
                if ((object.ReferenceEquals(this.GenreInfoField, value) != true)) {
                    this.GenreInfoField = value;
                    this.RaisePropertyChanged("GenreInfo");
                }
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
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ProducerDto", Namespace="http://schemas.datacontract.org/2004/07/NF.ApplicationServices.DTOs")]
    [System.SerializableAttribute()]
    public partial class ProducerDto : NF.Website.MoviesReference.BaseDto {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FirstNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LastNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ProducerInfoField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FirstName {
            get {
                return this.FirstNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FirstNameField, value) != true)) {
                    this.FirstNameField = value;
                    this.RaisePropertyChanged("FirstName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LastName {
            get {
                return this.LastNameField;
            }
            set {
                if ((object.ReferenceEquals(this.LastNameField, value) != true)) {
                    this.LastNameField = value;
                    this.RaisePropertyChanged("LastName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ProducerInfo {
            get {
                return this.ProducerInfoField;
            }
            set {
                if ((object.ReferenceEquals(this.ProducerInfoField, value) != true)) {
                    this.ProducerInfoField = value;
                    this.RaisePropertyChanged("ProducerInfo");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RatingDto", Namespace="http://schemas.datacontract.org/2004/07/NF.ApplicationServices.DTOs")]
    [System.SerializableAttribute()]
    public partial class RatingDto : NF.Website.MoviesReference.BaseDto {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
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
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MoviesReference.IMovies")]
    public interface IMovies {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMovies/GetMovies", ReplyAction="http://tempuri.org/IMovies/GetMoviesResponse")]
        NF.Website.MoviesReference.MovieDto[] GetMovies();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMovies/GetMovies", ReplyAction="http://tempuri.org/IMovies/GetMoviesResponse")]
        System.Threading.Tasks.Task<NF.Website.MoviesReference.MovieDto[]> GetMoviesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMovies/GetMoviesByReleaseCountry", ReplyAction="http://tempuri.org/IMovies/GetMoviesByReleaseCountryResponse")]
        NF.Website.MoviesReference.MovieDto[] GetMoviesByReleaseCountry(string releaseCountry);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMovies/GetMoviesByReleaseCountry", ReplyAction="http://tempuri.org/IMovies/GetMoviesByReleaseCountryResponse")]
        System.Threading.Tasks.Task<NF.Website.MoviesReference.MovieDto[]> GetMoviesByReleaseCountryAsync(string releaseCountry);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMovies/GetMovieById", ReplyAction="http://tempuri.org/IMovies/GetMovieByIdResponse")]
        NF.Website.MoviesReference.MovieDto GetMovieById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMovies/GetMovieById", ReplyAction="http://tempuri.org/IMovies/GetMovieByIdResponse")]
        System.Threading.Tasks.Task<NF.Website.MoviesReference.MovieDto> GetMovieByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMovies/PostMovie", ReplyAction="http://tempuri.org/IMovies/PostMovieResponse")]
        string PostMovie(NF.Website.MoviesReference.MovieDto movieDto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMovies/PostMovie", ReplyAction="http://tempuri.org/IMovies/PostMovieResponse")]
        System.Threading.Tasks.Task<string> PostMovieAsync(NF.Website.MoviesReference.MovieDto movieDto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMovies/PutMovie", ReplyAction="http://tempuri.org/IMovies/PutMovieResponse")]
        string PutMovie(NF.Website.MoviesReference.MovieDto movieDto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMovies/PutMovie", ReplyAction="http://tempuri.org/IMovies/PutMovieResponse")]
        System.Threading.Tasks.Task<string> PutMovieAsync(NF.Website.MoviesReference.MovieDto movieDto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMovies/DeleteMovie", ReplyAction="http://tempuri.org/IMovies/DeleteMovieResponse")]
        string DeleteMovie(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMovies/DeleteMovie", ReplyAction="http://tempuri.org/IMovies/DeleteMovieResponse")]
        System.Threading.Tasks.Task<string> DeleteMovieAsync(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMoviesChannel : NF.Website.MoviesReference.IMovies, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MoviesClient : System.ServiceModel.ClientBase<NF.Website.MoviesReference.IMovies>, NF.Website.MoviesReference.IMovies {
        
        public MoviesClient() {
        }
        
        public MoviesClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MoviesClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MoviesClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MoviesClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public NF.Website.MoviesReference.MovieDto[] GetMovies() {
            return base.Channel.GetMovies();
        }
        
        public System.Threading.Tasks.Task<NF.Website.MoviesReference.MovieDto[]> GetMoviesAsync() {
            return base.Channel.GetMoviesAsync();
        }
        
        public NF.Website.MoviesReference.MovieDto[] GetMoviesByReleaseCountry(string releaseCountry) {
            return base.Channel.GetMoviesByReleaseCountry(releaseCountry);
        }
        
        public System.Threading.Tasks.Task<NF.Website.MoviesReference.MovieDto[]> GetMoviesByReleaseCountryAsync(string releaseCountry) {
            return base.Channel.GetMoviesByReleaseCountryAsync(releaseCountry);
        }
        
        public NF.Website.MoviesReference.MovieDto GetMovieById(int id) {
            return base.Channel.GetMovieById(id);
        }
        
        public System.Threading.Tasks.Task<NF.Website.MoviesReference.MovieDto> GetMovieByIdAsync(int id) {
            return base.Channel.GetMovieByIdAsync(id);
        }
        
        public string PostMovie(NF.Website.MoviesReference.MovieDto movieDto) {
            return base.Channel.PostMovie(movieDto);
        }
        
        public System.Threading.Tasks.Task<string> PostMovieAsync(NF.Website.MoviesReference.MovieDto movieDto) {
            return base.Channel.PostMovieAsync(movieDto);
        }
        
        public string PutMovie(NF.Website.MoviesReference.MovieDto movieDto) {
            return base.Channel.PutMovie(movieDto);
        }
        
        public System.Threading.Tasks.Task<string> PutMovieAsync(NF.Website.MoviesReference.MovieDto movieDto) {
            return base.Channel.PutMovieAsync(movieDto);
        }
        
        public string DeleteMovie(int id) {
            return base.Channel.DeleteMovie(id);
        }
        
        public System.Threading.Tasks.Task<string> DeleteMovieAsync(int id) {
            return base.Channel.DeleteMovieAsync(id);
        }
    }
}

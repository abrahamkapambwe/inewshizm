using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace NewsAppWebRole.Models
{
    [DataContract]
    public class UploadFiles
    {
        [DataMember]
        public string FileName
        {
            get;
            set;
        }
         [DataMember]
        public string ContentType
        {
            get;
            set;
        }
         [DataMember]
        public string ContentLength
        {
            get;
            set;
        }
         [DataMember]
        public Stream Stream
        {
            get;
            set;
        }
    }
    [DataContract]
    public class AttributeName
    {
        [DataMember]
        public string AttributeNameType
        {
            get;
            set;
        }
    }
     [DataContract]
    public class AgentEmail
    {
         [DataMember]
        public Guid EmailID
        {
            get;
            set;
        }
         [DataMember]
        public string Phone
        {
            get;
            set;
        }
         [DataMember]
        public string UserEmail
        {
            get;
            set;
        }
         [DataMember]
        public string Message
        {
            get;
            set;
        }
         [DataMember]
        public string Name
        {
            get;
            set;
        }
         [DataMember]
        public string PropertyID
        {
            get;
            set;
        }
         [DataMember]
        public string UseID
        {
            get;
            set;
        }
         [DataMember]
        public string UniqueID
        {
            get;
            set;
        }
         [DataMember]
        public DateTime DateCreated
        {
            get;
            set;
        }
         [DataMember]
        public string AgentID
        {
            get;
            set;
        }
    }

    [DataContract]
    public class Favourite
    {
        [DataMember]
        public Guid FavouriteID
        {
            get;
            set;
        }
        [DataMember]
        public string PropertyID
        {
            get;
            set;
        }
        [DataMember]
        public string UserID
        {
            get;
            set;
        }
        [DataMember]
        public string UserName
        {
            get;
            set;
        }
    }
     [DataContract]
    public class WebOwner
    {
        [DataMember]
        public Guid WebOwnerID
        {
            get;
            set;
        }
         [DataMember]
        public string FirstName
        {
            get;
            set;
        }
        [DataMember]
        public string Surname
        {
            get;
            set;
        }
        [DataMember]
        public string HeardUs
        {
            get;
            set;
        }
        [DataMember]
        public string Phone
        {
            get;
            set;
        }

        [DataMember]
        public string Query
        {
            get;
            set;
        }
        [DataMember]
        public string Email
        {
            get;
            set;
        }
        [DataMember]
        public string Comment
        {
            get;
            set;
        }
    }
    [DataContract]
    public class PropertyTableAzure
    {
        [DataMember]
        public Guid PropertyID
        {
            get;
            set;
        }
        [DataMember]
        public string WebReference
        {
            get;
            set;
        }
        [DataMember]
        public string Url
        {
            get;
            set;
        }
        [DataMember]
        public string StreetNumber
        {
            get;
            set;
        }
        [DataMember]
        public string UnitNumber
        {
            get;
            set;
        }
        [DataMember]
        public string StreetName
        {
            get;
            set;
        }
        [DataMember]
        public string Municipality
        {
            get;
            set;
        }
        [DataMember]
        public string Suburb
        {
            get;
            set;
        }
        [DataMember]
        public string City
        {
            get;
            set;
        }
        [DataMember]
        public string Province
        {
            get;
            set;
        }
        [DataMember]
        public string Country
        {
            get;
            set;
        }
        [DataMember]
        public string PropertyType
        {
            get;
            set;
        }
        [DataMember]
        public string Latitude
        {
            get;
            set;
        }
        [DataMember]
        public string Longitude
        {
            get;
            set;
        }
        [DataMember]
        public string UserName
        {
            get;
            set;
        }
        [DataMember]
        public DateTime Added
        {
            get;
            set;
        }
        [DataMember]
        public string UserID
        {
            get;
            set;
        }
        [DataMember]
        private UsersTableAzure _usersTableAzure;
        [DataMember]
        public UsersTableAzure UsersTableAzure
        {
            get
            {
                if (_usersTableAzure == null)
                    _usersTableAzure = new UsersTableAzure();
                return _usersTableAzure;
            }
            set
            {
                _usersTableAzure = value;
            }
        }
        [DataMember]
        private EstateAgentAzure _estateAgentAzure;
        [DataMember]
        public EstateAgentAzure EstateAgentAzure
        {
            get
            {
                if (_estateAgentAzure == null)
                    _estateAgentAzure = new EstateAgentAzure();
                return _estateAgentAzure;
            }
            set
            { _estateAgentAzure = value; }
        }
        [DataMember]
        private PriceTableAzure _priceTableAzure;
        [DataMember]
        public PriceTableAzure PriceTableAzure
        {
            get
            {
                if (_priceTableAzure == null)
                    _priceTableAzure = new PriceTableAzure();
                return _priceTableAzure;
            }
            set
            {
                _priceTableAzure = value;
            }
        }
        [DataMember]
        private PreviewPropertyTableAzure _previewPropertyTableAzure;
        [DataMember]
        public PreviewPropertyTableAzure PreviewPropertyTableAzure
        {
            get
            {
                if (_previewPropertyTableAzure == null)
                    _previewPropertyTableAzure = new PreviewPropertyTableAzure();
                return _previewPropertyTableAzure;
            }
            set
            {
                _previewPropertyTableAzure = value;
            }
        }
        [DataMember]
        private AttributeTableAzure _attributeTableAzure;
        [DataMember]
        public AttributeTableAzure AttributeTableAzure
        {
            get
            {
                if (_attributeTableAzure == null)
                    _attributeTableAzure = new AttributeTableAzure();
                return _attributeTableAzure;
            }
            set
            {
                _attributeTableAzure = value;
            }

        }
        [DataMember]
        public NumberOfPropertyAzure NumberOfPropertyAzure
        {
            get;
            set;
        }
        [DataMember]
        private List<ImageUrlAzure> _imageUrlAzures;
        [DataMember]
        public List<ImageUrlAzure> ImageUrlAzures
        {
            get
            {
                if (_imageUrlAzures == null)
                    _imageUrlAzures = new List<ImageUrlAzure>();
                return _imageUrlAzures;
            }
            set
            {
                _imageUrlAzures = value;
            }
        }

    }
    [Serializable]
    public class UsersTableAzure
    {

        public Guid UserID
        {
            get;
            set;
        }
        public string Title
        {
            get;
            set;
        }
        public string FirstName
        {
            get;
            set;
        }
        public string Surname
        {
            get;
            set;
        }
        public string Cellphone
        {
            get;
            set;
        }
        public string HomePhone
        {
            get;
            set;
        }
        public string WorkPhone
        {
            get;
            set;
        }
        public string HomeAddress
        {
            get;
            set;
        }
        public string EmailAddress
        {
            get;
            set;
        }
        public string City
        {
            get;
            set;
        }
        public string Province
        {
            get;
            set;
        }
        public string UserName
        {
            get;
            set;
        }
        public string PostalCode
        {
            get;
            set;
        }
        public string IPAddress
        {
            get;
            set;
        }
    }
    [Serializable]
    public class EstateAgentAzure
    {

        public Guid EstateAgentID
        {
            get;
            set;
        }
        public string City
        {
            get;
            set;
        }
        public string Country
        {
            get;
            set;
        }
        public string Username
        {
            get;
            set;
        }
        public string State_Prov
        {
            get;
            set;
        }
        public string BusinessName
        {
            get;
            set;
        }
        public string BusinessPhone
        {
            get;
            set;
        }
        public string AgentAddress
        {
            get;
            set;
        }
        public string TwitterUrl
        {
            get;
            set;
        }
        public string WebsiteUrl
        {
            get;
            set;
        }
        public string FaceBookUrl
        {
            get;
            set;
        }
        public string FaxNumber
        {
            get;
            set;
        }
        public string ProfessionalTitle
        {
            get;
            set;
        }
        public string ProfessionalCategory
        {
            get;
            set;
        }
        public string LinkedIn
        {
            get;
            set;
        }

        public string AgentType
        {
            get;
            set;
        }
        public string HomeImprovement
        {
            get;
            set;
        }
        public string ProfilePhotoUrl
        {
            get;
            set;
        }
        public string ProfileVideoUrl
        {
            get;
            set;
        }
        public string Url
        {
            get;
            set;
        }
        public string Description
        {
            get;
            set;
        }
        public string PostalCode
        {
            get;
            set;
        }
        public string Road
        {
            get;
            set;
        }
        public DateTime DateStamp
        {
            get;
            set;
        }
        public string UserID
        {
            get;
            set;
        }
        public string ServiceArea
        {
            get;
            set;
        }
        public string IPAddress
        {
            get;
            set;
        }
        public string Longitude
        {
            get;
            set;
        }
        public string Latitude
        {
            get;
            set;
        }
        private UsersTableAzure _usersTableAzure;
        public UsersTableAzure UsersTableAzure
        {
            get
            {
                if (_usersTableAzure == null)
                    _usersTableAzure = new UsersTableAzure();
                return _usersTableAzure;
            }
            set
            {
                _usersTableAzure = value;
            }
        }
    }
    [Serializable]
    public class PriceTableAzure
    {
        public Guid PriceID
        {
            get;
            set;
        }
        public Guid PropertyID
        {
            get;
            set;
        }
        public string MonthlyRental
        {
            get;
            set;
        }
        public string Description
        {
            get;
            set;
        }
        public string Attributes
        {
            get;
            set;
        }

    }
    [Serializable]
    public class PreviewPropertyTableAzure
    {

        public Guid PropertyPreviewID
        {
            get;
            set;
        }
        public String UserName
        {
            get;
            set;
        }
        public int NumberOfView
        {
            get;
            set;
        }
        public string ListingStatus
        {
            get;
            set;
        }
        public Boolean InComplete
        {
            get;
            set;
        }
        public Boolean Approved
        {
            get;
            set;
        }
        public Boolean Active
        {
            get;
            set;
        }
        public Boolean Deleted
        {
            get;
            set;
        }
        public Boolean Expired
        {
            get;
            set;
        }
        public Boolean Reported
        {
            get;
            set;
        }
        public int Duration
        {
            get;
            set;
        }
        public string PaymentStatus
        {
            get;
            set;
        }
        public string IPAddress
        {
            get;
            set;
        }
        public Guid PropertyID
        {
            get;
            set;
        }
        public DateTime ActivedDate
        {
            get;
            set;
        }
        public DateTime ExpiryDate
        {
            get;
            set;
        }
        public DateTime StartDate
        {
            get;
            set;
        }
    }
    [Serializable]
    public class AttributeTableAzure
    {
        public Guid AttributeID
        {
            get;
            set;
        }
        public Guid PropertyID
        {
            get;
            set;
        }
        public string AccessGate
        {
            get;
            set;
        }
        public string AirCon
        {
            get;
            set;
        }
        public string Alarm
        {
            get;
            set;
        }
        public string Balcony
        {
            get;
            set;
        }
        public int? Bathrooms
        {
            get;
            set;
        }
        public int? BedRooms
        {
            get;
            set;
        }
        public string Borehole
        {
            get;
            set;
        }
        public string BuiltInBraai
        {
            get;
            set;
        }
        public string BuiltInCupBoard
        {
            get;
            set;
        }
        public string BusinessType
        {
            get;
            set;
        }
        public int? Carports
        {
            get;
            set;
        }
        public string ClubHouse
        {
            get;
            set;
        }
        public string Deck
        {
            get;
            set;
        }
        public string DiningArea
        {
            get;
            set;
        }
        public string DisabilityAccess
        {
            get;
            set;
        }
        public string ElectricFencing
        {
            get;
            set;
        }
        public string ElectricityIncluded
        {
            get;
            set;
        }
        public string EnSuite
        {
            get;
            set;
        }
        //public string ElectricFencing
        //{
        //    get;
        //    set;
        //}
        public string EntranceHall
        {
            get;
            set;
        }
        public string Family_TV
        {
            get;
            set;
        }
        public string FarmBuilding
        {
            get;
            set;
        }
        public string FarmName
        {
            get;
            set;
        }
        public string FarmType
        {
            get;
            set;
        }
        public string Fence
        {
            get;
            set;
        }
        public string Finishes
        {
            get;
            set;
        }
        public string Fireplace
        {
            get;
            set;
        }
        //public string Flatlet
        //{
        //    get;
        //    set;
        //}
        public string FloorArea
        {
            get;
            set;
        }
        public string Furnished
        {
            get;
            set;
        }
        public string Flatlet
        {
            get;
            set;
        }
        public string Garages
        {
            get;
            set;
        }
        public string GardenCottage
        {
            get;
            set;
        }
        public string Garden
        {
            get;
            set;
        }
        public string Golf
        {
            get;
            set;
        }
        public string GuestToilet
        {
            get;
            set;
        }
        //public string Garden
        //{
        //    get;
        //    set;
        //}
        public string Gym
        {
            get;
            set;
        }
        public string Storage
        {
            get;
            set;
        }
        public string HomeType
        {
            get;
            set;
        }
    }
    [Serializable]
    public class NumberOfPropertyAzure
    {

        public int PropNumberID
        {
            get;
            set;
        }
        public int EstateAgentID
        {
            get;
            set;
        }
        public int PropertyID
        {
            get;
            set;
        }
    }
    [Serializable]
    public class ImageUrlAzure
    {

        public Guid ImageUrlID
        {
            get;
            set;
        }
        public Guid PropertyID
        {
            get;
            set;
        }
        public string imageblob
        {
            get;
            set;
        }
        public string thumbnailblob
        {
            get;
            set;
        }

        public DateTime DateUploaded
        {
            get;
            set;
        }
        public string username
        {
            get;
            set;
        }
        public int Index
        {
            get;
            set;
        }
    }
   
}
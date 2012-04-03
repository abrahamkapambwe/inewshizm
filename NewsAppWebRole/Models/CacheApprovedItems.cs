using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsAppWebRole.Models
{
    public class CacheApprovedItems
    {
        private List<PropertyTableAzure> _propertyTablecache;
        public List<PropertyTableAzure> propertyTablecache
        {
            get
            {
                if (_propertyTablecache == null)
                    _propertyTablecache = new List<PropertyTableAzure>();
                return _propertyTablecache;
            }
            set
            {
                _propertyTablecache = value;
            }
        }
        public List<NumberOfPropertyAzure> numberOfPropertycache
        {
            get;
            set;
        }
        private List<EstateAgentAzure> _estateAgentlistcache;
        public List<EstateAgentAzure> estateAgentlistcache
        {
            get
            {
                if (_estateAgentlistcache == null)
                    _estateAgentlistcache = new List<EstateAgentAzure>();
                return _estateAgentlistcache;
            }
            set
            {
                _estateAgentlistcache = value;
            }
        }
        public List<PreviewPropertyTableAzure> previewPropertyTablelistcache
        {
            get;
            set;
        }

        public List<UsersTableAzure> userstablelistcache
        {
            get;
            set;
        }

        public List<AttributeTableAzure> attributelistcache
        {
            get;
            set;
        }


        public List<ImageUrlAzure> imageUrllistcache
        {
            get;
            set;
        }

        public List<PriceTableAzure> priceTablecache
        {
            get;
            set;
        }

    }
}
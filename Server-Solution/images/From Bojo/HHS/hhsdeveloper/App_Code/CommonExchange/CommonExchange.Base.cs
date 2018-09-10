using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;
using System.Collections;

namespace CommonExchange
{
    #region Common Structure Exchange

    [Serializable()]
    public class Users : BaseObject
    {
        public Users()
        {
            _id = String.Empty;
            _userName = String.Empty;
            _password = String.Empty;
            _isActive = false;
        }

        public Boolean Equals(Users obj)
        {
            if (base.Equals<Users>(obj))
            {
                return true;
            }

            return false;

        }

        private String _id;
        public String Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private String _userName;
        public String UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        private String _password;
        public String Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private Boolean _isActive;
        public Boolean IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }
    }

    /// <summary>
    /// This class is used for list that needs to be cloned. Source: http://programmingcorner.blogspot.com/2007_01_01_programmingcorner_archive.html
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable()]
    public class CloneableDictionaryList<T> : List<T>, ICloneable where T : class
    {
        public virtual Object Clone()
        {
            CloneableDictionaryList<T> newList = new CloneableDictionaryList<T>();

            if (this.Count > 0)
            {
                Type iCloneType = this[0].GetType().GetInterface("ICloneable", true);

                if (iCloneType != null)
                {
                    foreach (T value in this)
                    {
                        newList.Add((T)((ICloneable)value).Clone());
                    }
                }
                else
                {
                    foreach (T value in this)
                    {
                        newList.Add(value);
                    }
                }

                return newList;
            }
            else
            {
                return newList;
            }

        }
    }

    [Serializable()]
    public abstract class BaseObject : ICloneable
    {
        protected DataRowState _objectState;    //must be declared as protected in order for the data member to be include in the cloning.
        public DataRowState ObjectState
        {
            get { return _objectState; }
            set { _objectState = value; }
        }

        /// <summary>
        /// Clone the object, and returning a reference to a cloned object.
        /// Source: http://www.codeproject.com/KB/cs/cloneimpl_class.aspx
        /// </summary>
        /// <returns>reference to the new cloned object</returns>
        public Object Clone()
        {
            //create an instance of this specific type
            Object newObject = Activator.CreateInstance(this.GetType());

            //get the array of fields for the new type instance
            FieldInfo[] fields = newObject.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance | 
                BindingFlags.Public | BindingFlags.Static);

            Int32 i = 0;

            //foreach (FieldInfo fi in this.GetType().GetFields())
            foreach (FieldInfo fi in newObject.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance | 
                BindingFlags.Public | BindingFlags.Static))
            {
                //query if the fields support the ICloneable interface.
                Type ICloneType = fi.FieldType.GetInterface("ICloneable", true);

                if (ICloneType != null)
                {
                    //getting the ICloneable interface from the object
                    ICloneable IClone = (ICloneable)fi.GetValue(this);

                    if (fi.GetValue(this) != null)
                    {
                        //use the clone method to set the new value to the field.
                        fields[i].SetValue(newObject, IClone.Clone());
                    }
                }
                else
                {
                    if (fi.GetValue(this) != null)
                    {
                        //if the field doesn't support the ICloneable interface then just set it.
                        fields[i].SetValue(newObject, fi.GetValue(this));
                    }
                }

                //check if the object support the IEnumerable interface, so if it does
                //we need to enumerate all its items and check if they support the ICloneable interface
                Type IEnumerableType = fi.FieldType.GetInterface("IEnumerable", true);

                if (IEnumerableType != null)
                {
                    //get the IEnumerable interface from the field.
                    IEnumerable IEnum = (IEnumerable)fi.GetValue(this);

                    //this version support the IList and the IDictionary interfaces to iterate on collections.
                    Type IListType = fields[i].FieldType.GetInterface("IList", true);

                    Type IDicType = fields[i].FieldType.GetInterface("IDictionary", true);

                    Int32 j = 0;

                    if (IListType != null)
                    {
                        //getting the IList interface
                        IList list = (IList)fields[i].GetValue(newObject);

                        if (IEnum != null && list != null)
                        {
                            foreach (Object obj in IEnum)
                            {
                                //checks to see if the current item support the ICloneable interface
                                ICloneType = obj.GetType().GetInterface("ICloneable", true);

                                if (ICloneType != null)
                                {
                                    //if it does support the ICloneable interface, we use it to set the clone of the object in the list
                                    ICloneable clone = (ICloneable)obj;

                                    list[j] = clone.Clone();
                                }

                                //NOTE: If the item in the list is does not
                                //support the ICloneable interface then in the cloned list this item
                                //will be the same item as in the original list (as long as this type is a reference type).

                                j++;
                            }
                        }
                    }
                    else if (IDicType != null)
                    {
                        //getting the dictionary interface
                        IDictionary dic = (IDictionary)fields[i].GetValue(newObject);

                        if (dic != null)
                        {
                            j = 0;

                            foreach (DictionaryEntry de in IEnum)
                            {
                                //checking to see if the item support the ICloneable interface.
                                ICloneType = de.Value.GetType().GetInterface("ICloneable", true);

                                if (ICloneType != null)
                                {
                                    ICloneable clone = (ICloneable)de.Value;

                                    dic[de.Key] = clone.Clone();
                                }

                                j++;
                            }
                        }
                    }
                }

                i++;
            }

            return newObject;

        }

        protected Boolean Equals<T>(T obj) where T : class
        {
            if (obj != null)
            {
                PropertyInfo[] sourceProperties = this.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance |
                    BindingFlags.Public | BindingFlags.Static);

                foreach (PropertyInfo pi in sourceProperties)
                {
                    if (!(this.GetType().GetProperty(pi.Name).GetValue(this, null) == null ||
                        obj.GetType().GetProperty(pi.Name).GetValue(obj, null) == null) &&
                        !(String.Equals(this.GetType().GetProperty(pi.Name).GetValue(this, null).ToString(),
                        obj.GetType().GetProperty(pi.Name).GetValue(obj, null).ToString())))
                    {
                        return false;
                    }
                }

                return true;
            }

            return this == obj;
        }
    }

    [Serializable]
    public class SystemConfiguration
    {
        private SystemConfiguration() { }

        public static String LogoLocalImagesPath
        {
            get { return @"images\logo\"; }
        }

        public static String LogoVirtualImagePath
        {
            get { return @"~/images/logo/"; }
        }

        public static String NationalProviderWebAddress
        {
            get { return @"https://nppes.cms.hhs.gov/NPPES/Welcome.do"; }
        }

        public static String GoogleMapsWebAddress(String query)
        {
            return @"http://maps.google.com/maps?hl=en&q=" + query;
        }

        public static String TreeViewNodeTextSpace
        {
            get { return @"  ::  "; }
        }
    }

    [Serializable()]
    public class CacheName
    {
        private CacheName() { }

        /// <summary>
        /// Cache to be used: System.Web.Caching (Cache)
        /// </summary>
        public static String HomeHealthInformation
        {
            get { return @"jiUw@3*sw*4(0we_+wer:sd,vBwerOwefWero{swefner"; }
        }        
    }

    #endregion

}

using System;
using System.Collections.Generic;
using System.Text;

namespace FrictionTester
{
///// <summary>
// ///   Enum value adapter, used to get values from each Cultures.
// /// </summary>
//public sealed class EnumAdapter
// {
//     /**//// <summary>
//     ///   Storage the actual Enum value.
//     /// </summary>
//    private EnumType _value;

//    /**//// <summary>
//    ///   Constructor an <see cref="EnumAdapter"/>.
//   /// </summary>
//   /// <param name="value">The enum value.</param>
//    /// <exception cref="">
//    ///   
//   /// </exception>
//    public EnumAdapter(EnumType value)
//    {
//        if (!Enum.IsDefined(typeof(EnumType), value))
//       {
//           throw new ArgumentException(string.Format("{0} is not defined in {1}", value, typeof(EnumType).Name), "value");
//            // It's better use resource version as below.
//            // throw new ArgumentException(SR.GetString("ENUM_NOT_DEFINED_FMT_KEY", value, typeof(EnumType).Name), "value");
//        }
//        _value = value;
//    }

//    /**//// <summary>
//    ///   Gets the actual enum value.
//    /// </summary>
//   public EnumType Value
//    {
//       get { return _value; }
//    }

//    /**//// <summary>
//    ///   Gets the display value for enum value by search local resource with currrent UI culture 
//    ///   and special key which is concated from Enum type name and Enum value name.
//    /// </summary>
//   /// <remarks>
//    ///   This would get correct display value by accessing location resource with current UI Culture.
//    /// </remarks>
//   public string DisplayValue
//    {
//       get { return SR.GetString(string.Format("{0}.{1}", typeof(EnumType).Name, _value.ToString())); }
//    }

//    //TODO: If you want more, please add below
//}


    public class EnumValueStringPair
    {
        private readonly Enum m_Enum;

        public EnumValueStringPair(Enum _enum)
        {
            this.m_Enum = _enum;
        }

        /// <summary>
        /// 获取实际的枚举值。
        /// </summary>
        public Enum Enum
        {
            get { return this.m_Enum; }
        }

        /// <summary>
        /// 获取该枚举值对应的字符串。该字段从对应的资源文件中提取文本。
        /// </summary>
        public string EnumString
        {
//            get { return Properties.Resources.ResourceManager.GetString(this.m_Enum.ToString()); }
            get { return this.m_Enum.ToString(); }
        }
    }




}

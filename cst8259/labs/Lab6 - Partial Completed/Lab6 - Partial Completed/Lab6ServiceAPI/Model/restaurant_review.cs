﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;

// 
// This source code was auto-generated by xsd, Version=4.8.3928.0.
// 


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.algonquincollege.com/cst8259/labs")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://www.algonquincollege.com/cst8259/labs", IsNullable=false)]
public partial class restaurant_reviews {
    
    private restaurant_reviewsRestaurant[] restaurantField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("restaurant")]
    public restaurant_reviewsRestaurant[] restaurant {
        get {
            return this.restaurantField;
        }
        set {
            this.restaurantField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.algonquincollege.com/cst8259/labs")]
public partial class restaurant_reviewsRestaurant {
    
    private string nameField;
    
    private address addressField;
    
    private RangeType costField;
    
    private string food_typeField;
    
    private RangeType ratingField;
    
    private string summaryField;
    
    /// <remarks/>
    public string name {
        get {
            return this.nameField;
        }
        set {
            this.nameField = value;
        }
    }
    
    /// <remarks/>
    public address address {
        get {
            return this.addressField;
        }
        set {
            this.addressField = value;
        }
    }
    
    /// <remarks/>
    public RangeType cost {
        get {
            return this.costField;
        }
        set {
            this.costField = value;
        }
    }
    
    /// <remarks/>
    public string food_type {
        get {
            return this.food_typeField;
        }
        set {
            this.food_typeField = value;
        }
    }
    
    /// <remarks/>
    public RangeType rating {
        get {
            return this.ratingField;
        }
        set {
            this.ratingField = value;
        }
    }
    
    /// <remarks/>
    public string summary {
        get {
            return this.summaryField;
        }
        set {
            this.summaryField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.algonquincollege.com/cst8259/labs")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://www.algonquincollege.com/cst8259/labs", IsNullable=false)]
public partial class address {
    
    private string street_addressField;
    
    private string cityField;
    
    private StateProvinceType state_provinceField;
    
    private string zip_postal_codeField;
    
    /// <remarks/>
    public string street_address {
        get {
            return this.street_addressField;
        }
        set {
            this.street_addressField = value;
        }
    }
    
    /// <remarks/>
    public string city {
        get {
            return this.cityField;
        }
        set {
            this.cityField = value;
        }
    }
    
    /// <remarks/>
    public StateProvinceType state_province {
        get {
            return this.state_provinceField;
        }
        set {
            this.state_provinceField = value;
        }
    }
    
    /// <remarks/>
    public string zip_postal_code {
        get {
            return this.zip_postal_codeField;
        }
        set {
            this.zip_postal_codeField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.algonquincollege.com/cst8259/labs")]
public enum StateProvinceType {
    
    /// <remarks/>
    AB,
    
    /// <remarks/>
    BC,
    
    /// <remarks/>
    MB,
    
    /// <remarks/>
    NB,
    
    /// <remarks/>
    NL,
    
    /// <remarks/>
    NS,
    
    /// <remarks/>
    ON,
    
    /// <remarks/>
    PE,
    
    /// <remarks/>
    QC,
    
    /// <remarks/>
    NT,
    
    /// <remarks/>
    NU,
    
    /// <remarks/>
    YT,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.algonquincollege.com/cst8259/labs")]
public partial class RangeType {
    
    private byte minField;
    
    private byte maxField;
    
    private byte valueField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte min {
        get {
            return this.minField;
        }
        set {
            this.minField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte max {
        get {
            return this.maxField;
        }
        set {
            this.maxField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public byte Value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
}
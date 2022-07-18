﻿using OPCUA_Interop.ModelExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OPCUA_Interop.Managers
{
    public class uaObjectTypeDesignManager
    {
        ModelDesign model { get; set; }

        public uaObjectTypeDesignManager(ModelDesign model)
        {
            this.model = model;
            this.model.Items = new NodeDesign[] { };
        }

        //<ObjectType SymbolicName = "ANIMAL:AnimalType" BaseType="ua:BaseObjectType" IsAbstract="true" SupportsEvents="true">
        //        <Description>Base type for all animals</Description>
        public ObjectTypeDesignExtension AddBasicTypeDesign(string SymbolicName, string Description,string NameSpace)
        {
            ObjectTypeDesign newObjectTypeDesign = new ObjectTypeDesign
            {
                SymbolicName = new XmlQualifiedName(SymbolicName, NameSpace),
                BaseType = new XmlQualifiedName("BaseObjectType", "http://opcfoundation.org/UA/"),
                IsAbstract = false,
                SupportsEvents = true,
                Description = new LocalizedText()
                {
                    Value = Description
                },
                Children = new ListOfChildren()
            };

            List<NodeDesign> nodedesigns = model.Items.ToList();
            nodedesigns.Add(newObjectTypeDesign);
            model.Items = nodedesigns.ToArray();

            return new ObjectTypeDesignExtension(newObjectTypeDesign);
        }
    }
}
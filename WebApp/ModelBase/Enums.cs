using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.ModelBase
{
    public enum HeatingType
    {
        Gas,
        AirCondition,
        Stove,
        CentralHeating
    }
    public enum ResidentialType
    {
        Flat,
        Residence,
        Villa,
        FarmHouse
    }
    public enum SellType
    {
        ForSale,
        ForRent
    }
    public enum ZoningStatus
    {
        Field,
        Residentially,
        Commerically,
        SpecialUse,
        Industrially,
        ProtectedArea,

    }
    public enum BuildingType
    {
        OfficePlazaFloor,
        Detached,
        Store,
        ReadyForWorkOffices,
        Cafe,
        Collective,
        Manifacturing

    }
}
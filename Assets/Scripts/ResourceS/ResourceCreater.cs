using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceCreater : Creater
{
    public override Resource RandomCreate()
    {
        var i = Random.Range(0, 3);
        if (i == 0)
            return new Wood();
        else if(i == 1)
            return new Stone();
        else if (i == 2)
            return new Iron();
        return null;
    }
}

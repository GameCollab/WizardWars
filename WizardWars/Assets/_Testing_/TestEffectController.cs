using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEffectController : MonoBehaviour {
    public GameObject _manager;

    public DirectDamage _directdamage;
    public ProjectileDamage _projectiledamage;
    public AreaDamage _areadamage;

    public bool _testDirectDamage;
    public bool _testProjectileDamage;
    public bool _testAreaDamage;
	// Use this for initialization
	void Start () {
        if (_testDirectDamage)
        {
            Debug.Log("Test Effect Controller: Setting Direct Damage Active");
            _directdamage.enabled = true;
        }
        else if (_testProjectileDamage)
        {
            Debug.Log("Test Effect Controller: Setting Projectile Damage Active");
            _projectiledamage.enabled = true;
        }
        else if (_testAreaDamage)
        {
            Debug.Log("Test Effect Controller: Setting Area Damage Active");
            _areadamage.enabled = true;
        }
	}

    void Update()
    {
        Vector3 newpos = new Vector3();
        newpos.x -= 0.5f;
        //transform.Translate(newpos);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEffectController : MonoBehaviour {
    public GameObject _manager;

    public DirectDamage _directdamage;
    public ProjectileDamage _projectiledamage;
    public AreaDamage _areadamage;
    public DirectHeal _directheal;
    public DirectDisrupt _directDisrupt;
    public ProjectileMove _projectileMove;
    public ProjectileDisrupt _pdisrupt;
    public ProjectileDisplace _pdisplace;

    public Transform _target;

    public bool _testDirectDamage;
    public bool _testProjectileDamage;
    public bool _testAreaDamage;
    public bool _testDirectHeal;
    public bool _testDirectDisrupt;
    public bool _testProjectileMove;
    public bool _testProjectileDisrupt;
    public bool _testProjectileDisplace;
	// Use this for initialization
	void Start () {
        if (_testDirectDamage)
        {
            //Debug.Log("Test Effect Controller: Setting Direct Damage Active");
            _directdamage.enabled = true;
        }
        if (_testProjectileDamage)
        {
            //Debug.Log("Test Effect Controller: Setting Projectile Damage Active");
            _projectiledamage.enabled = true;
        }
        if (_testAreaDamage)
        {
            //Debug.Log("Test Effect Controller: Setting Area Damage Active");
            _areadamage.enabled = true;
        }
        if (_testDirectHeal)
        {
            _directheal.enabled = true;
        }
        if (_testDirectDisrupt)
        {
            _directDisrupt.enabled = true;
        }
        if (_testProjectileMove)
        {
            //_projectileMove._originPosition = transform;
            //_projectileMove._targetPosition = _target;
            _projectileMove.enabled = true;
        }
        if (_testProjectileDisplace)
        {
            //Debug.Log("Test Effect Controller: Setting Projectile Damage Active");
            _pdisplace.enabled = true;
        }
        if (_testProjectileDisrupt)
        {
            //Debug.Log("Test Effect Controller: Setting Projectile Damage Active");
            _pdisrupt.enabled = true;
        }
    }

    void Update()
    {
        Vector3 newpos = new Vector3();
        newpos.x -= 0.5f;
        //transform.Translate(newpos);
    }
}

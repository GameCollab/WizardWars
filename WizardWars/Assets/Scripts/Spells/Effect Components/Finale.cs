
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finale : Effect
{
    public GameObject _prefabThatReplaces;

    public GameObject _replacingObject;

    void Start()
    {

    }

    void OnEnable()
    {
        Initialize();

        DoDiscrete();
    }


    private void ApplyFinale()
    {

        _replacingObject = (GameObject)Instantiate(_prefabThatReplaces, transform.position, new Quaternion());
    }

    public override bool Done()
    {
        return _doneDiscrete;
    }


    public override void Initialize()
    {
        _isTargeted = false;
        _isProjectile = false;
        _isPersistent = false;
        _timer = 0f;
    }

    public override void DoDiscrete()
    {
        ApplyFinale();
        //Destroy(gameObject);
        _doneDiscrete = true;
    }

    public override IEnumerator DoContinuous()
    {
        //You cannot keep dying.
        yield break;
    }
}






/*using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finale : Effect {
    public GameObject _prefabThatReplaces;

    public GameObject _replacingObject;

    public bool _replaceOnDestroy;
    public bool _hasLifeTime;

    public float _lifetime;
    public float _decayRate;

    public bool _hasDecayed = false;

    void Start()
    {

    }

    void OnEnable()
    {
        Initialize();

        if (!_hasLifeTime)
        {
            DoDiscrete();
        }
    }

    void Update()
    {
        if (!Done())
        {
            if (_hasLifeTime && !_hasDecayed)
            {
                StartCoroutine(Decay());
            }
            if (_hasDecayed)
            {
                DoDiscrete();
            }
        }
    }
    
    private void ApplyFinale()
    {
        if (_replaceOnDestroy)
        {
            _replacingObject = (GameObject)Instantiate(_prefabThatReplaces, transform.position, new Quaternion());
        }
    } 

    private IEnumerator Decay()
    {
        while(_timer < _lifetime)
        {
            _timer += _decayRate;
            yield return new WaitForSeconds(_decayRate);
        }
        _hasDecayed = true;
        yield break;
    }

    public override bool Done()
    {
        return _doneDiscrete;
    }


    public override void Initialize()
    {
        _isTargeted = false;
        _isProjectile = false;
        _isPersistent = false;
        _timer = 0f;
    }

    public override void DoDiscrete()
    {
        ApplyFinale();
        //Destroy(gameObject);
        _doneDiscrete = true;
    }

    public override IEnumerator DoContinuous()
    {
        //You cannot keep dying.
        yield break;
    }
}
*/

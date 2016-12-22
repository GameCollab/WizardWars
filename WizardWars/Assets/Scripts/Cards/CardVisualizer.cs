using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardVisualizer : MonoBehaviour {
    public Animator _animator;
    public AudioSource _audio;
    public Button _mouseDetector;

    public bool _isSelected;
    public bool _isHovered;

    public GameObject _onHoverGlow;
    public GameObject _onSelectGlow;
    public GameObject _specialGlow;

    public Text _titlePartition;
    public Text _descriptorPartition;
    public Text _statPartition;

    public Image _cardImage;
    public Image _baseImage;
    public Image _rarityImage;
    public Image _classImage;

    public uint _id;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Display(Vector3 mousePosition)
    {

    }

    public void Select()
    {

    }

    public void Hover()
    {

    }

    public Card GetCardData()
    {
        return Utilities.ManagerAccess.GetCardById(_id).GetComponent<Card>();
    }
}

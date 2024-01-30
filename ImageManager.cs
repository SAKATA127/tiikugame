using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NovelGame
{
    public class ImageManager : MonoBehaviour
    {
        [SerializeField] Sprite _background1;
        [SerializeField] Sprite _background2;
        [SerializeField] Sprite _background3;
        [SerializeField] Sprite _background4;
        [SerializeField] Sprite _background5;
        [SerializeField] Sprite _background6;

        [SerializeField] Sprite _character1;
        [SerializeField] Sprite _character2;
        [SerializeField] Sprite _character3;
        [SerializeField] Sprite _character4;
        [SerializeField] Sprite _character5;
        [SerializeField] Sprite _character6;
        [SerializeField] Sprite _character7;
        [SerializeField] Sprite _character8;
        [SerializeField] Sprite _character9; 
        [SerializeField] Sprite _character10;
        [SerializeField] Sprite _character11; 
        [SerializeField] Sprite _character12; 
        [SerializeField] Sprite _character13; 
        [SerializeField] Sprite _character14;

        [SerializeField] GameObject _backgroundObject;
        [SerializeField] GameObject _character_leftObject;
        [SerializeField] GameObject _character_rightObject;
        [SerializeField] GameObject _imagePrefab;

        // テキストファイルから、文字列でSpriteやGameObjectを扱えるようにするための辞書
        Dictionary<string, Sprite> _textToSprite;
        Dictionary<string, GameObject> _textToParentObject;

        // 操作したいPrefabを指定できるようにするための辞書
        Dictionary<string, GameObject> _textToSpriteObject;

        void Awake()
        {
            _textToSprite = new Dictionary<string, Sprite>();

            _textToSprite.Add("background-01", _background1);
            _textToSprite.Add("background-02", _background2);
            _textToSprite.Add("background-03", _background3);
            _textToSprite.Add("background-04", _background4);
            _textToSprite.Add("background-05", _background5);
            _textToSprite.Add("background-black", _background6);

            _textToSprite.Add("character-01", _character1);
            _textToSprite.Add("character-02", _character2);
            _textToSprite.Add("character-03", _character3);
            _textToSprite.Add("character-04", _character4);
            _textToSprite.Add("character-05", _character5);
            _textToSprite.Add("character-06", _character6);
            _textToSprite.Add("character-07", _character7);
            _textToSprite.Add("character-08", _character8);
            _textToSprite.Add("character-09", _character9);
            _textToSprite.Add("character-10", _character10);
            _textToSprite.Add("character-11", _character11);
            _textToSprite.Add("character-12", _character12);
            _textToSprite.Add("character-13", _character13);
            _textToSprite.Add("character-14", _character14);

            _textToParentObject = new Dictionary<string, GameObject>();
            _textToParentObject.Add("backgroundObject", _backgroundObject);
            _textToParentObject.Add("character_leftObject", _character_leftObject);
            _textToParentObject.Add("character_rightObject", _character_rightObject);

            _textToSpriteObject = new Dictionary<string, GameObject>();
        }

        // 画像を配置する
        public void PutImage(string imageName, string parentObjectName, int x, int y)
        {
            Sprite image = _textToSprite[imageName];
            GameObject parentObject = _textToParentObject[parentObjectName];

            Vector2 position = new Vector2(x, y);
            Quaternion rotation = Quaternion.identity;
            Transform parent = parentObject.transform;
            GameObject item = Instantiate(_imagePrefab, position, rotation, parent);
            item.GetComponent<Image>().sprite = image;

            _textToSpriteObject.Add(imageName, item);
        }

        // 画像を削除する
        public void RemoveImage(string imageName)
        {
            Destroy(_textToSpriteObject[imageName]);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImgTestS2 : MonoBehaviour
{
    private Image mImage;
    public Sprite[] msprite;
    bool c;
    // Start is called before the first frame update
    void Start()
    {
        c = false;
        mImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // �X�v���C�g�I�u�W�F�N�g�̕ύX�t���O�� true �̏ꍇ
            if (c)
            {
                // �X�v���C�g�I�u�W�F�N�g�̕ύX
                //�i�z�� m_Sprite[0] �Ɋi�[�����X�v���C�g�I�u�W�F�N�g��ϐ� m_Image �Ɋi�[����Image �R���|�[�l���g�Ɋ��蓖�āj
                mImage.sprite = msprite[0];
                c = false;
            }
            // �X�v���C�g�I�u�W�F�N�g�̕ύX�t���O�� false �̏ꍇ
            else
            {
                // �X�v���C�g�I�u�W�F�N�g�̕ύX
                //�i�z�� m_Sprite[1] �Ɋi�[�����X�v���C�g�I�u�W�F�N�g��ϐ� m_Image �Ɋi�[����Image �R���|�[�l���g�Ɋ��蓖�āj
                mImage.sprite = msprite[1];
                c = true;
            }
        }
    }
}

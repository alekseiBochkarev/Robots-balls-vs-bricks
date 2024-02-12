using UnityEngine;
public class SceneConfiguration : MonoBehaviour
{
    public ObjectGamePosition[] _objectGamePositions;
    public ObjectGamePosition[] SetObjects() {
        return new ObjectGamePosition[1];
    }

    public void Awake()
    {
        Debug.Log("Awake for scene Configuration");
        switch (SaveManager.LoadDayData())
        {
            case 1:
                _objectGamePositions = new SceneConfiguration1().SetObjects();
                break;
            case 2:
                _objectGamePositions = new SceneConfiguration2().SetObjects();
                break;
            case 3:
                _objectGamePositions = new SceneConfiguration3().SetObjects();
                break;
            case 4:
                _objectGamePositions = new SceneConfiguration4().SetObjects();
                break;
            case 5:
                _objectGamePositions = new SceneConfiguration5().SetObjects();
                break;
            case 6:
                _objectGamePositions = new SceneConfiguration6().SetObjects();
                break;
            case 7:
                _objectGamePositions = new SceneConfiguration7().SetObjects();
                break;
            case 8:
                _objectGamePositions = new SceneConfiguration8().SetObjects();
                break;
            case 9:
                _objectGamePositions = new SceneConfiguration9().SetObjects();
                break;
            case 10:
                _objectGamePositions = new SceneConfiguration10().SetObjects();
                break;
            case 11:
                _objectGamePositions = new SceneConfiguration11().SetObjects();
                break;
            case 12:
                _objectGamePositions = new SceneConfiguration12().SetObjects();
                break;
            case 13:
                _objectGamePositions = new SceneConfiguration13().SetObjects();
                break;
            case 14:
                _objectGamePositions = new SceneConfiguration14().SetObjects();
                break;
            case 15:
                _objectGamePositions = new SceneConfiguration15().SetObjects();
                break;
            case 16:
                _objectGamePositions = new SceneConfiguration16().SetObjects();
                break;
            case 17:
                _objectGamePositions = new SceneConfiguration17().SetObjects();
                break;
            case 18:
                _objectGamePositions = new SceneConfiguration18().SetObjects();
                break;
            case 19:
                _objectGamePositions = new SceneConfiguration19().SetObjects();
                break;
            case 20:
                _objectGamePositions = new SceneConfiguration20().SetObjects();
                break;
            case 21:
                _objectGamePositions = new SceneConfiguration21().SetObjects();
                break;
            case 22:
                _objectGamePositions = new SceneConfiguration22().SetObjects();
                break;
            case 23:
                _objectGamePositions = new SceneConfiguration23().SetObjects();
                break;
            case 24:
                _objectGamePositions = new SceneConfiguration24().SetObjects();
                break;
            case 25:
                _objectGamePositions = new SceneConfiguration25().SetObjects();
                break;
            case 26:
                _objectGamePositions = new SceneConfiguration26().SetObjects();
                break;
            case 27:
                _objectGamePositions = new SceneConfiguration27().SetObjects();
                break;
            case 28:
                _objectGamePositions = new SceneConfiguration28().SetObjects();
                break;
            case 29:
                _objectGamePositions = new SceneConfiguration29().SetObjects();
                break;
            case 30:
                _objectGamePositions = new SceneConfiguration30().SetObjects();
                break;
            case 31:
                _objectGamePositions = new SceneConfiguration31().SetObjects();
                break;
            case 32:
                _objectGamePositions = new SceneConfiguration32().SetObjects();
                break;
            case 33:
                _objectGamePositions = new SceneConfiguration33().SetObjects();
                break;
            case 34:
                _objectGamePositions = new SceneConfiguration34().SetObjects();
                break;
            case 35:
                _objectGamePositions = new SceneConfiguration35().SetObjects();
                break;
            case 36:
                _objectGamePositions = new SceneConfiguration36().SetObjects();
                break;
            case 37:
                _objectGamePositions = new SceneConfiguration37().SetObjects();
                break;
            case 38:
                _objectGamePositions = new SceneConfiguration38().SetObjects();
                break;
            case 39:
                _objectGamePositions = new SceneConfiguration39().SetObjects();
                break;
            case 40:
                _objectGamePositions = new SceneConfiguration40().SetObjects();
                break;
            case 41:
                _objectGamePositions = new SceneConfiguration41().SetObjects();
                break;
            case 42:
                _objectGamePositions = new SceneConfiguration42().SetObjects();
                break;
            case 43:
                _objectGamePositions = new SceneConfiguration43().SetObjects();
                break;
            case 44:
                _objectGamePositions = new SceneConfiguration44().SetObjects();
                break;
            case 45:
                _objectGamePositions = new SceneConfiguration45().SetObjects();
                break;
            case 46:
                _objectGamePositions = new SceneConfiguration46().SetObjects();
                break;
            case 47:
                _objectGamePositions = new SceneConfiguration47().SetObjects();
                break;
            case 48:
                _objectGamePositions = new SceneConfiguration48().SetObjects();
                break;
            case 49:
                _objectGamePositions = new SceneConfiguration49().SetObjects();
                break;
            case 50:
                _objectGamePositions = new SceneConfiguration50().SetObjects();
                break;
            case 51:
                _objectGamePositions = new SceneConfiguration51().SetObjects();
                break;
            case 52:
                _objectGamePositions = new SceneConfiguration52().SetObjects();
                break;
            case 53:
                _objectGamePositions = new SceneConfiguration53().SetObjects();
                break;
            case 54:
                _objectGamePositions = new SceneConfiguration54().SetObjects();
                break;
            case 55:
                _objectGamePositions = new SceneConfiguration55().SetObjects();
                break;
            case 56:
                _objectGamePositions = new SceneConfiguration56().SetObjects();
                break;
            case 59:
                _objectGamePositions = new SceneConfiguration59().SetObjects();
                break;
            case 62:
                _objectGamePositions = new SceneConfiguration62().SetObjects();
                break;
            case 65:
                _objectGamePositions = new SceneConfiguration65().SetObjects();
                break;
            case 68:
                _objectGamePositions = new SceneConfiguration68().SetObjects();
                break;
            case 71:
                _objectGamePositions = new SceneConfiguration71().SetObjects();
                break;
            case 74:
                _objectGamePositions = new SceneConfiguration74().SetObjects();
                break;
            case 77:
                _objectGamePositions = new SceneConfiguration77().SetObjects();
                break;
            case 80:
                _objectGamePositions = new SceneConfiguration80().SetObjects();
                break;
            case 83:
                _objectGamePositions = new SceneConfiguration83().SetObjects();
                break;
            case 86:
                _objectGamePositions = new SceneConfiguration86().SetObjects();
                break;
            case 89:
                _objectGamePositions = new SceneConfiguration89().SetObjects();
                break;
            case 92:
                _objectGamePositions = new SceneConfiguration92().SetObjects();
                break;
            case 95:
                _objectGamePositions = new SceneConfiguration95().SetObjects();
                break;
            case 98:
                _objectGamePositions = new SceneConfiguration98().SetObjects();
                break;
            case 101:
                _objectGamePositions = new SceneConfiguration101().SetObjects();
                break;
            case 104:
                _objectGamePositions = new SceneConfiguration104().SetObjects();
                break;
            default:
                _objectGamePositions = new SceneConfigurationRR().SetObjects();
                break;
        }
        

    }

}
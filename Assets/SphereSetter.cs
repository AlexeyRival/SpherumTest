using UnityEngine;

public class SphereSetter : MonoBehaviour
{
    public Renderer[] spheres;
    private readonly string param = "_Shift";//избежать лишних аллокаций
    void Start()
    {
        MaterialPropertyBlock block;   
        for (int i = 0; i < spheres.Length; ++i)
        {
            block = new MaterialPropertyBlock();
            block.SetVector(param, new Vector4(((i)%8)*.125f,1f-((i)/8*.25f)-.25f));
            spheres[i].SetPropertyBlock(block);
        }
    }

}

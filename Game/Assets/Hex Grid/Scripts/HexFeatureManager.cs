using UnityEngine;

public class HexFeatureManager : MonoBehaviour
{
	Transform container;

	public void Clear() 
	{
	if (container)
        {
			Destroy(container.gameObject);
        }
		container = new GameObject("Features Container").transform;
		container.SetParent(transform, false);
	}

	public void Apply() { }

	public void AddFeature(HexCell cell, Vector3 position) 
	{
		HexHash hash = HexMetrics.SampleHashGrid(position);
		//if (hash.a >= cell.UrbanLevel * 0.25f)
		//  {
		//		return;
		//   }
		//Transform instance = Instantiate(urbanPrefabs[cell.UrbanLevel - 1]);
		Transform prefab = PickPrefab(
			urbanCollections, cell.UrbanLevel, hash.a, hash.d
			);
		Transform otherPrefab = PickPrefab(
			farmCollections, cell.FarmLevel, hash.b, hash.d
			);
		float usedHash = hash.a;
		if (prefab)
        {
			if (otherPrefab && hash.b < hash.a)
            {
				prefab = otherPrefab;
				usedHash = hash.b;
            }
        }
		else if (otherPrefab)
        {
			prefab = otherPrefab;
			usedHash = hash.b;
		}
		otherPrefab = PickPrefab(
			mineCollections, cell.MineLevel, hash.c, hash.d
		);
		if (prefab)
		{
			if (otherPrefab && hash.c < usedHash)
			{
				prefab = otherPrefab;
				usedHash = hash.c;
			}
		}
		else if (otherPrefab)
		{
			prefab = otherPrefab;
			usedHash = hash.c;
		}
		otherPrefab = PickPrefab(
	jungleCollections, cell.JungleLevel, hash.f, hash.d
); ;
		if (prefab)
		{
			if (otherPrefab && hash.f < usedHash)
			{
				prefab = otherPrefab;
				usedHash = hash.f;
			}
		}
		else if (otherPrefab)
		{
			prefab = otherPrefab;
			usedHash = hash.f;
		}
		otherPrefab = PickPrefab(
	tforestCollections, cell.TforestLevel, hash.g, hash.d
);
		if (prefab)
		{
			if (otherPrefab && hash.g < usedHash)
			{
				prefab = otherPrefab;
				usedHash = hash.g;
			}
		}
		else if (otherPrefab)
		{
			prefab = otherPrefab;
			usedHash = hash.g;
		}
		otherPrefab = PickPrefab(
	pforestCollections, cell.PforestLevel, hash.h, hash.d
);
		if (prefab)
		{
			if (otherPrefab && hash.h < usedHash)
			{
				prefab = otherPrefab;
				usedHash = hash.h;
			}
		}
		else if (otherPrefab)
		{
			prefab = otherPrefab;
			usedHash = hash.h;
		}
		otherPrefab = PickPrefab(
	fplainsCollections, cell.FplainsLevel, hash.i, hash.d
);
		if (prefab)
		{
			if (otherPrefab && hash.i < usedHash)
			{
				prefab = otherPrefab;
				usedHash = hash.i;
			}
		}
		else if (otherPrefab)
		{
			prefab = otherPrefab;
			usedHash = hash.i;
		}
		otherPrefab = PickPrefab(
	forestryCollections, cell.ForestryLevel, hash.j, hash.d
);
		if (prefab)
		{
			if (otherPrefab && hash.j < usedHash)
			{
				prefab = otherPrefab;
				usedHash = hash.j;
			}
		}
		else if (otherPrefab)
		{
			prefab = otherPrefab;
			usedHash = hash.j;
		}
		otherPrefab = PickPrefab(
	iceCollections, cell.IceLevel, hash.k, hash.d
);
		if (prefab)
		{
			if (otherPrefab && hash.k < usedHash)
			{
				prefab = otherPrefab;
				usedHash = hash.k;
			}
		}
		else if (otherPrefab)
		{
			prefab = otherPrefab;
			usedHash = hash.k;
		}
		otherPrefab = PickPrefab(
	reefCollections, cell.ReefLevel, hash.l, hash.d
);
		if (prefab)
		{
			if (otherPrefab && hash.l < usedHash)
			{
				prefab = otherPrefab;
				usedHash = hash.l;
			}
		}
		else if (otherPrefab)
		{
			prefab = otherPrefab;
			usedHash = hash.l;
		}
		otherPrefab = PickPrefab(
	dockCollections, cell.DockLevel, hash.m, hash.d
);
		if (prefab)
		{
			if (otherPrefab && hash.m < usedHash)
			{
				prefab = otherPrefab;
				usedHash = hash.m;
			}
		}
		else if (otherPrefab)
		{
			prefab = otherPrefab;
			usedHash = hash.m;
		}
		otherPrefab = PickPrefab(
	coalCollections, cell.CoalLevel, hash.n, hash.d
);
		if (prefab)
		{
			if (otherPrefab && hash.n < usedHash)
			{
				prefab = otherPrefab;
				usedHash = hash.n;
			}
		}
		else if (otherPrefab)
		{
			prefab = otherPrefab;
			usedHash = hash.n;
		}
		otherPrefab = PickPrefab(
	ironCollections, cell.IronLevel, hash.o, hash.d
);
		if (prefab)
		{
			if (otherPrefab && hash.o < usedHash)
			{
				prefab = otherPrefab;
				usedHash = hash.o;
			}
		}
		else if (otherPrefab)
		{
			prefab = otherPrefab;
			usedHash = hash.o;
		}
		otherPrefab = PickPrefab(
	oilCollections, cell.OilLevel, hash.p, hash.d
);
		if (prefab)
		{
			if (otherPrefab && hash.p < usedHash)
			{
				prefab = otherPrefab;
				usedHash = hash.p;
			}
		}
		else if (otherPrefab)
		{
			prefab = otherPrefab;
			usedHash = hash.p;
		}
		otherPrefab = PickPrefab(
	copperCollections, cell.CopperLevel, hash.q, hash.d
);
		if (prefab)
		{
			if (otherPrefab && hash.q < usedHash)
			{
				prefab = otherPrefab;
				usedHash = hash.q;
			}
		}
		else if (otherPrefab)
		{
			prefab = otherPrefab;
			usedHash = hash.q;
		}
		otherPrefab = PickPrefab(
	goldCollections, cell.GoldLevel, hash.r, hash.d
);
		if (prefab)
		{
			if (otherPrefab && hash.r < usedHash)
			{
				prefab = otherPrefab;
				usedHash = hash.r;
			}
		}
		else if (otherPrefab)
		{
			prefab = otherPrefab;
			usedHash = hash.r;
		}
		otherPrefab = PickPrefab(
	magicrystalCollections, cell.MagicrystalLevel, hash.s, hash.d
);
		if (prefab)
		{
			if (otherPrefab && hash.s < usedHash)
			{
				prefab = otherPrefab;
				usedHash = hash.s;
			}
		}
		else if (otherPrefab)
		{
			prefab = otherPrefab;
			usedHash = hash.s;
		}
		otherPrefab = PickPrefab(
	magisteelCollections, cell.MagisteelLevel, hash.t, hash.d
);
		if (prefab)
		{
			if (otherPrefab && hash.t < usedHash)
			{
				prefab = otherPrefab;
				usedHash = hash.t;
			}
		}
		else if (otherPrefab)
		{
			prefab = otherPrefab;
			usedHash = hash.t;
		}
		otherPrefab = PickPrefab(
	uraniumCollections, cell.UraniumLevel, hash.u, hash.d
);
		if (prefab)
		{
			if (otherPrefab && hash.u < usedHash)
			{
				prefab = otherPrefab;
				usedHash = hash.u;
			}
		}
		else if (otherPrefab)
		{
			prefab = otherPrefab;
			usedHash = hash.u;
		}
		otherPrefab = PickPrefab(
	rubbertreeCollections, cell.RubbertreeLevel, hash.v, hash.d
);
		if (prefab)
		{
			if (otherPrefab && hash.v < usedHash)
			{
				prefab = otherPrefab;
				usedHash = hash.v;
			}
		}
		else if (otherPrefab)
		{
			prefab = otherPrefab;
			usedHash = hash.v;
		}
		otherPrefab = PickPrefab(
	aluminumCollections, cell.AluminumLevel, hash.w, hash.d
);
		if (prefab)
		{
			if (otherPrefab && hash.w < usedHash)
			{
				prefab = otherPrefab;
				usedHash = hash.w;
			}
		}
		else if (otherPrefab)
		{
			prefab = otherPrefab;
			usedHash = hash.w;
		}
		otherPrefab = PickPrefab(
	leadCollections, cell.LeadLevel, hash.x, hash.d
);
		if (prefab)
		{
			if (otherPrefab && hash.x < usedHash)
			{
				prefab = otherPrefab;
				usedHash = hash.x;
			}
		}
		else if (otherPrefab)
		{
			prefab = otherPrefab;
			usedHash = hash.x;
		}
		otherPrefab = PickPrefab(
	mercuryCollections, cell.MercuryLevel, hash.y, hash.d
);
		if (prefab)
		{
			if (otherPrefab && hash.y < usedHash)
			{
				prefab = otherPrefab;
				usedHash = hash.y;
			}
		}
		else if (otherPrefab)
		{
			prefab = otherPrefab;
			usedHash = hash.y;
		}
		otherPrefab = PickPrefab(
	tinCollections, cell.TinLevel, hash.z, hash.d
);
		if (prefab)
		{
			if (otherPrefab && hash.z < usedHash)
			{
				prefab = otherPrefab;
				usedHash = hash.z;
			}
		}
		else if (otherPrefab)
		{
			prefab = otherPrefab;
			usedHash = hash.z;
		}
		otherPrefab = PickPrefab(
	sulfurCollections, cell.SulfurLevel, hash.za, hash.d
);
		if (prefab)
		{
			if (otherPrefab && hash.za < usedHash)
			{
				prefab = otherPrefab;
				usedHash = hash.za;
			}
		}
		else if (otherPrefab)
		{
			prefab = otherPrefab;
			usedHash = hash.za;
		}
		otherPrefab = PickPrefab(
	niterCollections, cell.NiterLevel, hash.zb, hash.d
);
		if (prefab)
		{
			if (otherPrefab && hash.zb < usedHash)
			{
				prefab = otherPrefab;
			}
		}
		else if (otherPrefab)
		{
			prefab = otherPrefab;
		}
		else
        {
			return;
        }
		Transform instance = Instantiate(prefab);
		position.y += instance.localScale.y * 0.5f;
		instance.localPosition = HexMetrics.Perturb(position);
		instance.localRotation = Quaternion.Euler(0f, 360f * hash.e, 0f);
		instance.SetParent(container, false);
	}

	//public Transform featurePrefab;
	//public Transform[][] urbanPrefabs;
	public HexFeatureCollection[]
		urbanCollections, jungleCollections, tforestCollections, pforestCollections, farmCollections, fplainsCollections, mineCollections, forestryCollections, iceCollections, reefCollections, dockCollections, coalCollections, ironCollections, oilCollections, copperCollections, goldCollections, magicrystalCollections, magisteelCollections, uraniumCollections, rubbertreeCollections, aluminumCollections, leadCollections, mercuryCollections, tinCollections, sulfurCollections, niterCollections;
	Transform PickPrefab(
		HexFeatureCollection[] collection,
		int level, float hash, float choice
	)
	{
		if (level > 0)
		{
			float[] thresholds = HexMetrics.GetFeatureThresholds(level - 1);
			for (int i = 0; i < thresholds.Length; i++)
			{
				if (hash < thresholds[i])
				{
					return collection[i].Pick(choice);
				}
			}
		}
		return null;
	}
}

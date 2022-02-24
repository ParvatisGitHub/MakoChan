using UnityEngine;

public class HexFeatureManager : MonoBehaviour
{
	Transform container;

	public HexMesh walls;

	public void Clear() 
	{
	if (container)
        {
			Destroy(container.gameObject);
        }
		container = new GameObject("Features Container").transform;
		container.SetParent(transform, false);
		walls.Clear();
	}

	public void Apply() {
		walls.Apply();
	}



	public void AddWall(
		EdgeVertices near, HexCell nearCell,
		EdgeVertices far, HexCell farCell,
		bool hasRiver, bool hasRoad
	)
	{
		if (
			nearCell.Walled != farCell.Walled &&
			!nearCell.IsUnderwater && !farCell.IsUnderwater &&
			nearCell.GetEdgeType(farCell) != HexEdgeType.Cliff
		)
		{
			AddWallSegment(near.v1, far.v1, near.v2, far.v2);
			if (hasRiver || hasRoad)
			{
				AddWallCap(near.v2, far.v2);
				AddWallCap(far.v4, near.v4);
			}
			else
			{
				AddWallSegment(near.v2, far.v2, near.v3, far.v3);
				AddWallSegment(near.v3, far.v3, near.v4, far.v4);
			}
			AddWallSegment(near.v4, far.v4, near.v5, far.v5);
		}
	}

	public void AddWall(
		Vector3 c1, HexCell cell1,
		Vector3 c2, HexCell cell2,
		Vector3 c3, HexCell cell3
	)
	{
		if (cell1.Walled)
		{
			if (cell2.Walled)
			{
				if (!cell3.Walled)
				{
					AddWallSegment(c3, cell3, c1, cell1, c2, cell2);
				}
			}
			else if (cell3.Walled)
			{
				AddWallSegment(c2, cell2, c3, cell3, c1, cell1);
			}
			else
			{
				AddWallSegment(c1, cell1, c2, cell2, c3, cell3);
			}
		}
		else if (cell2.Walled)
		{
			if (cell3.Walled)
			{
				AddWallSegment(c1, cell1, c2, cell2, c3, cell3);
			}
			else
			{
				AddWallSegment(c2, cell2, c3, cell3, c1, cell1);
			}
		}
		else if (cell3.Walled)
		{
			AddWallSegment(c3, cell3, c1, cell1, c2, cell2);
		}
	}

	void AddWallSegment(
		Vector3 nearLeft, Vector3 farLeft, Vector3 nearRight, Vector3 farRight
	)
	{
		nearLeft = HexMetrics.Perturb(nearLeft);
		farLeft = HexMetrics.Perturb(farLeft);
		nearRight = HexMetrics.Perturb(nearRight);
		farRight = HexMetrics.Perturb(farRight);

		Vector3 left = HexMetrics.WallLerp(nearLeft, farLeft);
		Vector3 right = HexMetrics.WallLerp(nearRight, farRight);

		Vector3 leftThicknessOffset =
			HexMetrics.WallThicknessOffset(nearLeft, farLeft);
		Vector3 rightThicknessOffset =
			HexMetrics.WallThicknessOffset(nearRight, farRight);

		float leftTop = left.y + HexMetrics.wallHeight;
		float rightTop = right.y + HexMetrics.wallHeight;

		Vector3 v1, v2, v3, v4;
		v1 = v3 = left - leftThicknessOffset;
		v2 = v4 = right - rightThicknessOffset;
		v3.y = leftTop;
		v4.y = rightTop;
		walls.AddQuadUnperturbed(v1, v2, v3, v4);

		Vector3 t1 = v3, t2 = v4;

		v1 = v3 = left + leftThicknessOffset;
		v2 = v4 = right + rightThicknessOffset;
		v3.y = leftTop;
		v4.y = rightTop;
		walls.AddQuadUnperturbed(v2, v1, v4, v3);

		walls.AddQuadUnperturbed(t1, t2, v3, v4);
	}

	void AddWallSegment(
		Vector3 pivot, HexCell pivotCell,
		Vector3 left, HexCell leftCell,
		Vector3 right, HexCell rightCell
	)
	{
		if (pivotCell.IsUnderwater)
		{
			return;
		}

		bool hasLeftWall = !leftCell.IsUnderwater &&
			pivotCell.GetEdgeType(leftCell) != HexEdgeType.Cliff;
		bool hasRighWall = !rightCell.IsUnderwater &&
			pivotCell.GetEdgeType(rightCell) != HexEdgeType.Cliff;

		if (hasLeftWall)
		{
			if (hasRighWall)
			{
				AddWallSegment(pivot, left, pivot, right);
			}
			else if (leftCell.Elevation < rightCell.Elevation)
			{
				AddWallWedge(pivot, left, right);
			}
			else
			{
				AddWallCap(pivot, left);
			}
		}
		else if (hasRighWall)
		{
			if (rightCell.Elevation < leftCell.Elevation)
			{
				AddWallWedge(right, pivot, left);
			}
			else
			{
				AddWallCap(right, pivot);
			}
		}
	}

	void AddWallCap(Vector3 near, Vector3 far)
	{
		near = HexMetrics.Perturb(near);
		far = HexMetrics.Perturb(far);

		Vector3 center = HexMetrics.WallLerp(near, far);
		Vector3 thickness = HexMetrics.WallThicknessOffset(near, far);

		Vector3 v1, v2, v3, v4;

		v1 = v3 = center - thickness;
		v2 = v4 = center + thickness;
		v3.y = v4.y = center.y + HexMetrics.wallHeight;
		walls.AddQuadUnperturbed(v1, v2, v3, v4);
	}

	void AddWallWedge(Vector3 near, Vector3 far, Vector3 point)
	{
		near = HexMetrics.Perturb(near);
		far = HexMetrics.Perturb(far);
		point = HexMetrics.Perturb(point);

		Vector3 center = HexMetrics.WallLerp(near, far);
		Vector3 thickness = HexMetrics.WallThicknessOffset(near, far);

		Vector3 v1, v2, v3, v4;
		Vector3 pointTop = point;
		point.y = center.y;

		v1 = v3 = center - thickness;
		v2 = v4 = center + thickness;
		v3.y = v4.y = pointTop.y = center.y + HexMetrics.wallHeight;

		walls.AddQuadUnperturbed(v1, point, v3, pointTop);
		walls.AddQuadUnperturbed(point, v2, pointTop, v4);
		walls.AddTriangleUnperturbed(pointTop, v3, v4);
	}

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

using UnityEngine;

public class HexCell : MonoBehaviour {

	public HexCoordinates coordinates;

	public RectTransform uiRect;

	public HexGridChunk chunk;

	public Color Color {
		get {
			return color;
		}
		set {
			if (color == value) {
				return;
			}
			color = value;
			Refresh();
		}
	}
	//Jungle, Temperate, Pine forests, FloodPlains, Farms, Urban
	//Coal, Iron, Oil, Copper, Gold, MagiCrystals, MagiSteel, Uranium, RubberTrees, Aluminum, Lead, Mercury, Tin, Sulfur, Niter
	//Ice, Reefs, Docks
	//JungleLevel TforestLevel PforestLevel FarmLevel FplainsLevel UrbanLevel MineLevel ForestryLevel IceLevel ReefLevel DockLevel CoalLevel IronLevel OilLevel CopperLevel GoldLevel MagicrystalLevel MagisteelLevel
	//UraniumLevel RubbertreeLevel AluminumLevel LeadLevel MercuryLevel TinLevel SulfurLevel NiterLevel
	//holy fuck writing that out was hard
	//Niter
	public int NiterLevel
	{
		get
		{
			return niterLevel;
		}
		set
		{
			if (niterLevel != value)
			{
				niterLevel = value;
				RefreshSelfOnly();
			}
		}
	}
	//Sulfur
	public int SulfurLevel
	{
		get
		{
			return sulfurLevel;
		}
		set
		{
			if (sulfurLevel != value)
			{
				sulfurLevel = value;
				RefreshSelfOnly();
			}
		}
	}
	//Tin
	public int TinLevel
	{
		get
		{
			return tinLevel;
		}
		set
		{
			if (tinLevel != value)
			{
				tinLevel = value;
				RefreshSelfOnly();
			}
		}
	}
	//Mercury
	public int MercuryLevel
	{
		get
		{
			return mercuryLevel;
		}
		set
		{
			if (mercuryLevel != value)
			{
				mercuryLevel = value;
				RefreshSelfOnly();
			}
		}
	}
	//Lead
	public int LeadLevel
	{
		get
		{
			return leadLevel;
		}
		set
		{
			if (leadLevel != value)
			{
				leadLevel = value;
				RefreshSelfOnly();
			}
		}
	}
	//Aluminum
	public int AluminumLevel
	{
		get
		{
			return aluminumLevel;
		}
		set
		{
			if (aluminumLevel != value)
			{
				aluminumLevel = value;
				RefreshSelfOnly();
			}
		}
	}
	//Rubber!!!! rubber trees
	public int RubbertreeLevel
	{
		get
		{
			return rubbertreeLevel;
		}
		set
		{
			if (rubbertreeLevel != value)
			{
				rubbertreeLevel = value;
				RefreshSelfOnly();
			}
		}
	}
	//Uranium
	public int UraniumLevel
	{
		get
		{
			return uraniumLevel;
		}
		set
		{
			if (uraniumLevel != value)
			{
				uraniumLevel = value;
				RefreshSelfOnly();
			}
		}
	}
	//MagiSteel
	public int MagisteelLevel
	{
		get
		{
			return magisteelLevel;
		}
		set
		{
			if (magisteelLevel != value)
			{
				magisteelLevel = value;
				RefreshSelfOnly();
			}
		}
	}
	//MagiCrystals
	public int MagicrystalLevel
	{
		get
		{
			return magicrystalLevel;
		}
		set
		{
			if (magicrystalLevel != value)
			{
				magicrystalLevel = value;
				RefreshSelfOnly();
			}
		}
	}
	//Gold
	public int GoldLevel
	{
		get
		{
			return goldLevel;
		}
		set
		{
			if (goldLevel != value)
			{
				goldLevel = value;
				RefreshSelfOnly();
			}
		}
	}
	//Copper
	public int CopperLevel
	{
		get
		{
			return copperLevel;
		}
		set
		{
			if (copperLevel != value)
			{
				copperLevel = value;
				RefreshSelfOnly();
			}
		}
	}
	//Oil
	public int OilLevel
	{
		get
		{
			return oilLevel;
		}
		set
		{
			if (oilLevel != value)
			{
				oilLevel = value;
				RefreshSelfOnly();
			}
		}
	}
	//Iron
	public int IronLevel
	{
		get
		{
			return ironLevel;
		}
		set
		{
			if (ironLevel != value)
			{
				ironLevel = value;
				RefreshSelfOnly();
			}
		}
	}
	//Coal
	public int CoalLevel
	{
		get
		{
			return coalLevel;
		}
		set
		{
			if (coalLevel != value)
			{
				coalLevel = value;
				RefreshSelfOnly();
			}
		}
	}
	//Docks
	public int DockLevel
	{
		get
		{
			return dockLevel;
		}
		set
		{
			if (dockLevel != value)
			{
				dockLevel = value;
				RefreshSelfOnly();
			}
		}
	}
	//Reefs
	public int ReefLevel
	{
		get
		{
			return reefLevel;
		}
		set
		{
			if (reefLevel != value)
			{
				reefLevel = value;
				RefreshSelfOnly();
			}
		}
	}
	//Ice
	public int IceLevel
	{
		get
		{
			return iceLevel;
		}
		set
		{
			if (iceLevel != value)
			{
				iceLevel = value;
				RefreshSelfOnly();
			}
		}
	}
	//Forestry
	public int ForestryLevel
	{
		get
		{
			return forestryLevel;
		}
		set
		{
			if (forestryLevel != value)
			{
				forestryLevel = value;
				RefreshSelfOnly();
			}
		}
	}
	//Mines
	public int MineLevel
	{
		get
		{
			return mineLevel;
		}
		set
		{
			if (mineLevel != value)
			{
				mineLevel = value;
				RefreshSelfOnly();
			}
		}
	}


	//Jungle Forest
	public int JungleLevel
	{
		get
		{
			return jungleLevel;
		}
		set
		{
			if (jungleLevel != value)
			{
				jungleLevel = value;
				RefreshSelfOnly();
			}
		}
	}
	//Temperate Forest
	public int TforestLevel
	{
		get
		{
			return tforestLevel;
		}
		set
		{
			if (tforestLevel != value)
			{
				tforestLevel = value;
				RefreshSelfOnly();
			}
		}
	}
	//Pine Forest
	public int PforestLevel
	{
		get
		{
			return pforestLevel;
		}
		set
		{
			if (pforestLevel != value)
			{
				pforestLevel = value;
				RefreshSelfOnly();
			}
		}
	}
	//Farms
	public int FarmLevel
	{
		get
		{
			return farmLevel;
		}
		set
		{
			if (farmLevel != value)
			{
				farmLevel = value;
				RefreshSelfOnly();
			}
		}
	}
	//FloodPlains
	public int FplainsLevel
	{
		get
		{
			return fplainsLevel;
		}
		set
		{
			if (fplainsLevel != value)
			{
				fplainsLevel = value;
				RefreshSelfOnly();
			}
		}
	}
	public int UrbanLevel
    {
		get
        {
			return urbanLevel;
        }
		set
        {
			if (urbanLevel != value)
            {
				urbanLevel = value;
				RefreshSelfOnly();
            }
        }
    }

	int urbanLevel, jungleLevel, tforestLevel, pforestLevel, farmLevel, fplainsLevel, mineLevel, forestryLevel, iceLevel, reefLevel, dockLevel, coalLevel, ironLevel, oilLevel, copperLevel, goldLevel;
	int magicrystalLevel, magisteelLevel, uraniumLevel, rubbertreeLevel, aluminumLevel, leadLevel, mercuryLevel, tinLevel, sulfurLevel, niterLevel;

	public int Elevation {
		get {
			return elevation;
		}
		set {
			if (elevation == value) {
				return;
			}
			elevation = value;
			Vector3 position = transform.localPosition;
			position.y = value * HexMetrics.elevationStep;
			position.y +=
				(HexMetrics.SampleNoise(position).y * 2f - 1f) *
				HexMetrics.elevationPerturbStrength;
			transform.localPosition = position;

			Vector3 uiPosition = uiRect.localPosition;
			uiPosition.z = -position.y;
			uiRect.localPosition = uiPosition;

			ValidateRivers();

			for (int i = 0; i < roads.Length; i++) {
				if (roads[i] && GetElevationDifference((HexDirection)i) > 1) {
					SetRoad(i, false);
				}
			}

			Refresh();
		}
	}

	public int WaterLevel {
		get {
			return waterLevel;
		}
		set {
			if (waterLevel == value) {
				return;
			}
			waterLevel = value;
			ValidateRivers();
			Refresh();
		}
	}

	public bool Walled
	{
		get
		{
			return walled;
		}
		set
		{
			if (walled != value)
			{
				walled = value;
				Refresh();
			}
		}
	}

	bool walled;






	public bool IsUnderwater {
		get {
			return waterLevel > elevation;
		}
	}

	public bool HasIncomingRiver {
		get {
			return hasIncomingRiver;
		}
	}

	public bool HasOutgoingRiver {
		get {
			return hasOutgoingRiver;
		}
	}

	public bool HasRiver {
		get {
			return hasIncomingRiver || hasOutgoingRiver;
		}
	}

	public bool HasRiverBeginOrEnd {
		get {
			return hasIncomingRiver != hasOutgoingRiver;
		}
	}

	public HexDirection RiverBeginOrEndDirection {
		get {
			return hasIncomingRiver ? incomingRiver : outgoingRiver;
		}
	}

	public bool HasRoads {
		get {
			for (int i = 0; i < roads.Length; i++) {
				if (roads[i]) {
					return true;
				}
			}
			return false;
		}
	}

	public HexDirection IncomingRiver {
		get {
			return incomingRiver;
		}
	}

	public HexDirection OutgoingRiver {
		get {
			return outgoingRiver;
		}
	}

	public Vector3 Position {
		get {
			return transform.localPosition;
		}
	}


	public float StreamBedY {
		get {
			return
				(elevation + HexMetrics.streamBedElevationOffset) *
				HexMetrics.elevationStep;
		}
	}

	public float RiverSurfaceY {
		get {
			return
				(elevation + HexMetrics.waterElevationOffset) *
				HexMetrics.elevationStep;
		}
	}

	public float WaterSurfaceY {
		get {
			return
				(waterLevel + HexMetrics.waterElevationOffset) *
				HexMetrics.elevationStep;
		}
	}

	Color color;

	int elevation = int.MinValue;
	int waterLevel;

	bool hasIncomingRiver, hasOutgoingRiver;
	HexDirection incomingRiver, outgoingRiver;

	[SerializeField]
	HexCell[] neighbors;

	[SerializeField]
	bool[] roads;

	public HexCell GetNeighbor (HexDirection direction) {
		return neighbors[(int)direction];
	}

	public void SetNeighbor (HexDirection direction, HexCell cell) {
		neighbors[(int)direction] = cell;
		cell.neighbors[(int)direction.Opposite()] = this;
	}

	public HexEdgeType GetEdgeType (HexDirection direction) {
		return HexMetrics.GetEdgeType(
			elevation, neighbors[(int)direction].elevation
		);
	}

	public HexEdgeType GetEdgeType (HexCell otherCell) {
		return HexMetrics.GetEdgeType(
			elevation, otherCell.elevation
		);
	}

	public bool HasRiverThroughEdge (HexDirection direction) {
		return
			hasIncomingRiver && incomingRiver == direction ||
			hasOutgoingRiver && outgoingRiver == direction;
	}

	public void RemoveIncomingRiver () {
		if (!hasIncomingRiver) {
			return;
		}
		hasIncomingRiver = false;
		RefreshSelfOnly();

		HexCell neighbor = GetNeighbor(incomingRiver);
		neighbor.hasOutgoingRiver = false;
		neighbor.RefreshSelfOnly();
	}

	public void RemoveOutgoingRiver () {
		if (!hasOutgoingRiver) {
			return;
		}
		hasOutgoingRiver = false;
		RefreshSelfOnly();

		HexCell neighbor = GetNeighbor(outgoingRiver);
		neighbor.hasIncomingRiver = false;
		neighbor.RefreshSelfOnly();
	}

	public void RemoveRiver () {
		RemoveOutgoingRiver();
		RemoveIncomingRiver();
	}

	public void SetOutgoingRiver (HexDirection direction) {
		if (hasOutgoingRiver && outgoingRiver == direction) {
			return;
		}

		HexCell neighbor = GetNeighbor(direction);
		if (!IsValidRiverDestination(neighbor)) {
			return;
		}

		RemoveOutgoingRiver();
		if (hasIncomingRiver && incomingRiver == direction) {
			RemoveIncomingRiver();
		}
		hasOutgoingRiver = true;
		outgoingRiver = direction;

		neighbor.RemoveIncomingRiver();
		neighbor.hasIncomingRiver = true;
		neighbor.incomingRiver = direction.Opposite();

		SetRoad((int)direction, false);
	}

	public bool HasRoadThroughEdge (HexDirection direction) {
		return roads[(int)direction];
	}

	public void AddRoad (HexDirection direction) {
		if (
			!roads[(int)direction] && !HasRiverThroughEdge(direction) &&
			GetElevationDifference(direction) <= 1
		) {
			SetRoad((int)direction, true);
		}
	}

	public void RemoveRoads () {
		for (int i = 0; i < neighbors.Length; i++) {
			if (roads[i]) {
				SetRoad(i, false);
			}
		}
	}

	public int GetElevationDifference (HexDirection direction) {
		int difference = elevation - GetNeighbor(direction).elevation;
		return difference >= 0 ? difference : -difference;
	}

	bool IsValidRiverDestination (HexCell neighbor) {
		return neighbor && (
			elevation >= neighbor.elevation || waterLevel == neighbor.elevation
		);
	}

	void ValidateRivers () {
		if (
			hasOutgoingRiver &&
			!IsValidRiverDestination(GetNeighbor(outgoingRiver))
		) {
			RemoveOutgoingRiver();
		}
		if (
			hasIncomingRiver &&
			!GetNeighbor(incomingRiver).IsValidRiverDestination(this)
		) {
			RemoveIncomingRiver();
		}
	}

	void SetRoad (int index, bool state) {
		roads[index] = state;
		neighbors[index].roads[(int)((HexDirection)index).Opposite()] = state;
		neighbors[index].RefreshSelfOnly();
		RefreshSelfOnly();
	}

	void Refresh () {
		if (chunk) {
			chunk.Refresh();
			for (int i = 0; i < neighbors.Length; i++) {
				HexCell neighbor = neighbors[i];
				if (neighbor != null && neighbor.chunk != chunk) {
					neighbor.chunk.Refresh();
				}
			}
		}
	}

	void RefreshSelfOnly () {
		chunk.Refresh();
	}
}
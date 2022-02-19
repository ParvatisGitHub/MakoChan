using UnityEngine;
using UnityEngine.EventSystems;

public class HexMapEditor : MonoBehaviour {

	public Color[] colors;

	public HexGrid hexGrid;

	int activeElevation;
	int activeWaterLevel;
	int activeUrbanLevel, activeJungleLevel, activeTforestLevel, activePforestLevel, activeFarmLevel, activeFplainsLevel, activeMineLevel, activeForestryLevel, activeIceLevel, activeReefLevel, activeDockLevel, activeCoalLevel, activeIronLevel, activeOilLevel, activeCopperLevel, activeGoldLevel;
	int activeMagicrystalLevel, activeMagisteelLevel, activeUraniumLevel, activeRubbertreeLevel, activeAluminumLevel, activeLeadLevel, activeMercuryLevel, activeTinLevel, activeSulfurLevel, activeNiterLevel;

	Color activeColor;

	int brushSize;

	bool applyColor;
	bool applyElevation = true;
	bool applyWaterLevel = true;
	bool applyUrbanLevel, applyJungleLevel, applyTforestLevel, applyPforestLevel, applyFarmLevel, applyFplainsLevel, applyMineLevel, applyForestryLevel, applyIceLevel, applyReefLevel, applyDockLevel, applyCoalLevel, applyIronLevel, applyOilLevel, applyCopperLevel, applyGoldLevel;
	bool applyMagicrystalLevel, applyMagisteelLevel, applyUraniumLevel, applyRubbertreeLevel, applyAluminumLevel, applyLeadLevel, applyMercuryLevel, applyTinLevel, applySulfurLevel, applyNiterLevel;

	enum OptionalToggle {
		Ignore, Yes, No
	}

	OptionalToggle riverMode, roadMode;

	bool isDrag;
	HexDirection dragDirection;
	HexCell previousCell;

	public void SelectColor (int index) {
		applyColor = index >= 0;
		if (applyColor) {
			activeColor = colors[index];
		}
	}
	public void SetApplyJungleLevel(bool toggle)
	{
		applyJungleLevel = toggle;
	}

	public void SetJungleLevel(float level)
	{
		activeJungleLevel = (int)level;
	}
	public void SetApplyTforestLevel(bool toggle)
	{
		applyTforestLevel = toggle;
	}

	public void SetTforestLevel(float level)
	{
		activeTforestLevel = (int)level;
	}
	public void SetApplyPforestLevel(bool toggle)
	{
		applyPforestLevel = toggle;
	}

	public void SetPforestLevel(float level)
	{
		activePforestLevel = (int)level;
	}
	public void SetApplyFarmLevel(bool toggle)
	{
		applyFarmLevel = toggle;
	}

	public void SetFarmLevel(float level)
	{
		activeFarmLevel = (int)level;
	}
	public void SetApplyFplainsLevel(bool toggle)
	{
		applyFplainsLevel = toggle;
	}

	public void SetFplainsLevel(float level)
	{
		activeFplainsLevel = (int)level;
	}
	public void SetApplyMineLevel(bool toggle)
	{
		applyMineLevel = toggle;
	}

	public void SetMineLevel(float level)
	{
		activeMineLevel = (int)level;
	}
	public void SetApplyForestryLevel(bool toggle)
	{
		applyForestryLevel = toggle;
	}

	public void SetForestryLevel(float level)
	{
		activeForestryLevel = (int)level;
	}
	public void SetApplyIceLevel(bool toggle)
	{
		applyIceLevel = toggle;
	}

	public void SetIceLevel(float level)
	{
		activeIceLevel = (int)level;
	}
	public void SetApplyReefLevel(bool toggle)
	{
		applyReefLevel = toggle;
	}

	public void SetReefLevel(float level)
	{
		activeReefLevel = (int)level;
	}
	public void SetApplyDockLevel(bool toggle)
	{
		applyDockLevel = toggle;
	}

	public void SetDockLevel(float level)
	{
		activeDockLevel = (int)level;
	}
	public void SetApplyCoalLevel(bool toggle)
	{
		applyCoalLevel = toggle;
	}

	public void SetCoalLevel(float level)
	{
		activeCoalLevel = (int)level;
	}
	public void SetApplyIronLevel(bool toggle)
	{
		applyIronLevel = toggle;
	}

	public void SetIronLevel(float level)
	{
		activeIronLevel = (int)level;
	}
	public void SetApplyOilLevel(bool toggle)
	{
		applyOilLevel = toggle;
	}

	public void SetOilLevel(float level)
	{
		activeOilLevel = (int)level;
	}
	public void SetApplyCopperLevel(bool toggle)
	{
		applyCopperLevel = toggle;
	}

	public void SetCopperLevel(float level)
	{
		activeCopperLevel = (int)level;
	}
	public void SetApplyGoldLevel(bool toggle)
	{
		applyGoldLevel = toggle;
	}

	public void SetGoldLevel(float level)
	{
		activeGoldLevel = (int)level;
	}
	public void SetApplyMagicrystalLevel(bool toggle)
	{
		applyMagicrystalLevel = toggle;
	}

	public void SetMagicrystalLevel(float level)
	{
		activeMagicrystalLevel = (int)level;
	}
	public void SetApplyMagisteelLevel(bool toggle)
	{
		applyMagisteelLevel = toggle;
	}

	public void SetMagisteelLevel(float level)
	{
		activeMagisteelLevel = (int)level;
	}
	public void SetApplyUraniumLevel(bool toggle)
	{
		applyUraniumLevel = toggle;
	}

	public void SetUraniumLevel(float level)
	{
		activeUraniumLevel = (int)level;
	}
	public void SetApplyRubbertreeLevel(bool toggle)
	{
		applyRubbertreeLevel = toggle;
	}

	public void SetRubbertreeLevel(float level)
	{
		activeRubbertreeLevel = (int)level;
	}
	public void SetApplyAluminumLevel(bool toggle)
	{
		applyAluminumLevel = toggle;
	}

	public void SetAluminumLevel(float level)
	{
		activeAluminumLevel = (int)level;
	}
	public void SetApplyLeadLevel(bool toggle)
	{
		applyLeadLevel = toggle;
	}

	public void SetLeadLevel(float level)
	{
		activeLeadLevel = (int)level;
	}
	public void SetApplyMercuryLevel(bool toggle)
	{
		applyMercuryLevel = toggle;
	}

	public void SetMercuryLevel(float level)
	{
		activeMercuryLevel = (int)level;
	}
	public void SetApplyTinLevel(bool toggle)
	{
		applyTinLevel = toggle;
	}

	public void SetTinLevel(float level)
	{
		activeTinLevel = (int)level;
	}
	public void SetApplySulfurLevel(bool toggle)
	{
		applySulfurLevel = toggle;
	}

	public void SetSulfurLevel(float level)
	{
		activeSulfurLevel = (int)level;
	}
	public void SetApplyNiterLevel(bool toggle)
	{
		applyNiterLevel = toggle;
	}

	public void SetNiterLevel(float level)
	{
		activeNiterLevel = (int)level;
	}

	public void SetApplyUrbanLevel (bool toggle)
    {
		applyUrbanLevel = toggle;
    }

	public void SetUrbanLevel (float level)
    {
		activeUrbanLevel = (int)level;
    }

	public void SetApplyElevation (bool toggle) {
		applyElevation = toggle;
	}

	public void SetElevation (float elevation) {
		activeElevation = (int)elevation;
	}

	public void SetApplyWaterLevel (bool toggle) {
		applyWaterLevel = toggle;
	}
	public void SetWaterLevel (float level) {
		activeWaterLevel = (int)level;
	}

	public void SetBrushSize (float size) {
		brushSize = (int)size;
	}

	public void SetRiverMode (int mode) {
		riverMode = (OptionalToggle)mode;
	}

	public void SetRoadMode (int mode) {
		roadMode = (OptionalToggle)mode;
	}

	public void ShowUI (bool visible) {
		hexGrid.ShowUI(visible);
	}

	void Awake () {
		SelectColor(0);
	}

	void Update () {
		if (
			Input.GetMouseButton(0) &&
			!EventSystem.current.IsPointerOverGameObject()
		) {
			HandleInput();
		}
		else {
			previousCell = null;
		}
	}

	void HandleInput () {
		Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(inputRay, out hit)) {
			HexCell currentCell = hexGrid.GetCell(hit.point);
			if (previousCell && previousCell != currentCell) {
				ValidateDrag(currentCell);
			}
			else {
				isDrag = false;
			}
			EditCells(currentCell);
			previousCell = currentCell;
		}
		else {
			previousCell = null;
		}
	}

	void ValidateDrag (HexCell currentCell) {
		for (
			dragDirection = HexDirection.NE;
			dragDirection <= HexDirection.NW;
			dragDirection++
		) {
			if (previousCell.GetNeighbor(dragDirection) == currentCell) {
				isDrag = true;
				return;
			}
		}
		isDrag = false;
	}

	void EditCells (HexCell center) {
		int centerX = center.coordinates.X;
		int centerZ = center.coordinates.Z;

		for (int r = 0, z = centerZ - brushSize; z <= centerZ; z++, r++) {
			for (int x = centerX - r; x <= centerX + brushSize; x++) {
				EditCell(hexGrid.GetCell(new HexCoordinates(x, z)));
			}
		}
		for (int r = 0, z = centerZ + brushSize; z > centerZ; z--, r++) {
			for (int x = centerX - brushSize; x <= centerX + r; x++) {
				EditCell(hexGrid.GetCell(new HexCoordinates(x, z)));
			}
		}
	}

	void EditCell (HexCell cell) {
		if (cell) {
			if (applyColor) {
				cell.Color = activeColor;
			}
			if (applyElevation) {
				cell.Elevation = activeElevation;
			}
			if (applyWaterLevel) {
				cell.WaterLevel = activeWaterLevel;
			}
			if (applyUrbanLevel)
            {
				cell.UrbanLevel = activeUrbanLevel;
            }
			if (riverMode == OptionalToggle.No) {
				cell.RemoveRiver();
			}
			if (roadMode == OptionalToggle.No) {
				cell.RemoveRoads();
			}
			if (isDrag) {
				HexCell otherCell = cell.GetNeighbor(dragDirection.Opposite());
				if (otherCell) {
					if (riverMode == OptionalToggle.Yes) {
						otherCell.SetOutgoingRiver(dragDirection);
					}
					if (roadMode == OptionalToggle.Yes) {
						otherCell.AddRoad(dragDirection);
					}
				}
			}
		}
	}
}
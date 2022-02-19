using UnityEngine;

public struct HexHash {

	public float a, b, c, d, e, f, g, h, i, j, k, l, m ,n, o, p, q, r, s, t, u, v, w, x, y, z, za, zb;

	public static HexHash Create () {
		HexHash hash;
		hash.a = Random.value * 0.999f; //Urban
		hash.b = Random.value * 0.999f; //Farm
		hash.c = Random.value * 0.999f; //Mine
		hash.d = Random.value * 0.999f; //varient choice
		hash.e = Random.value * 0.999f; // rotation
		hash.f = Random.value * 0.999f; //jungle
		hash.g = Random.value * 0.999f; //tforest
		hash.h = Random.value * 0.999f; //pforest
		hash.i = Random.value * 0.999f; //fplains
		hash.j = Random.value * 0.999f; //forestry
		hash.k = Random.value * 0.999f; //ice
		hash.l = Random.value * 0.999f; //reef
		hash.m = Random.value * 0.999f; //dock
		hash.n = Random.value * 0.999f; //coal
		hash.o = Random.value * 0.999f; //iron
		hash.p = Random.value * 0.999f; //oil
		hash.q = Random.value * 0.999f; //copper
		hash.r = Random.value * 0.999f; //gold
		hash.s = Random.value * 0.999f; //magicrystal
		hash.t = Random.value * 0.999f; //magisteel
		hash.u = Random.value * 0.999f; //uranium
		hash.v = Random.value * 0.999f; //rubbertree
		hash.w = Random.value * 0.999f; //aluminum
		hash.x = Random.value * 0.999f; //lead
		hash.y = Random.value * 0.999f; //mercury
		hash.z = Random.value * 0.999f; //tin
		hash.za = Random.value * 0.999f; //sulfur
		hash.zb = Random.value * 0.999f; //niter
		return hash;
	}
}
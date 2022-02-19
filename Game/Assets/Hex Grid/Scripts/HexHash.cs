using UnityEngine;

public struct HexHash {

	public float a, b, c, d, e, f, g, h, i, j, k, l, m ,n, o, p, q, r, s, t, u, v, w, x, y, z, za, zb;

	public static HexHash Create () {
		HexHash hash;
		hash.a = Random.value * 0.999f;
		hash.b = Random.value * 0.999f;
		hash.c = Random.value * 0.999f;
		hash.d = Random.value * 0.999f;
		hash.e = Random.value * 0.999f;
		hash.f = Random.value * 0.999f;
		hash.g = Random.value * 0.999f;
		hash.h = Random.value * 0.999f;
		hash.i = Random.value * 0.999f;
		hash.j = Random.value * 0.999f;
		hash.k = Random.value * 0.999f;
		hash.l = Random.value * 0.999f;
		hash.m = Random.value * 0.999f;
		hash.n = Random.value * 0.999f;
		hash.o = Random.value * 0.999f;
		hash.p = Random.value * 0.999f;
		hash.q = Random.value * 0.999f;
		hash.r = Random.value * 0.999f;
		hash.s = Random.value * 0.999f;
		hash.t = Random.value * 0.999f;
		hash.u = Random.value * 0.999f;
		hash.v = Random.value * 0.999f;
		hash.w = Random.value * 0.999f;
		hash.x = Random.value * 0.999f;
		hash.y = Random.value * 0.999f;
		hash.z = Random.value * 0.999f;
		hash.za = Random.value * 0.999f;
		hash.zb = Random.value * 0.999f;
		return hash;
	}
}
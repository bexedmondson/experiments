﻿using UnityEngine;

public class Graph : MonoBehaviour
{
	public Transform pointPrefab;

	[Range( 10, 100 )]
	public int resolution = 10;

	Transform[] points;

	void Awake()
	{
		float step = 2f / resolution;

		Vector3 scale = Vector3.one * step;

		Vector3 position = Vector3.zero;

		points = new Transform[ resolution ];

		for( int i = 0; i < points.Length; i++ )
		{
			Transform point = Instantiate( pointPrefab );
			position.x = ( i + 0.5f ) * step - 1f;
			point.localPosition = position;
			point.localScale = scale;
			point.SetParent( transform, false );
			points[ i ] = point;
		}
	}

	void Update()
	{
		float time = Time.time;

		for( int i = 0; i < points.Length; i++ )
		{
			Transform point = points[ i ];
			Vector3 position = point.localPosition;
			position.y = MultiSineFunction( position.x, time );
			point.localPosition = position;
		}
	}

	float SineFunction( float x, float t )
	{
		return Mathf.Sin( Mathf.PI * ( x + t ) );
	}

	float MultiSineFunction( float x, float t )
	{
		float y = Mathf.Sin( Mathf.PI * ( x + t ) );
		y += Mathf.Sin( 2f * Mathf.PI * ( x + t ) ) / 2f;
		y *= 2f / 3f;
		return y;
	}
}
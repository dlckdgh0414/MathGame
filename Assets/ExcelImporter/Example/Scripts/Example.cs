﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class Example : MonoBehaviour
{
	[SerializeField] MstItems mstItems;
	[SerializeField] TextMeshProUGUI _text;

	void Start()
	{
		ShowItems();
	}

	void ShowItems()
	{
		string str = "";

		mstItems.Entities
			.ForEach(entity => str += DescribeMstItemEntity(entity) + "\n");

		_text.text = str;
	}

	string DescribeMstItemEntity(MstItemEntity entity)
	{
		return string.Format(
			"{0} : {1}, {2}, {3}, {4}, {5}",
			entity.id,
			entity.name,
			entity.price,
			entity.isNotForSale,
			entity.rate,
			entity.category
		);
	}
}


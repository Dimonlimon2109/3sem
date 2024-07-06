#pragma once
#include "stdafx.h"

namespace Serialization {
	void Serialize(char* filePath, bool* boolean, int size);
	void Serialize(char* filePath, char symbols[][10], int size, int sizes[]);
}
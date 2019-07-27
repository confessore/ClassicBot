int64_t WowBase = reinterpret_cast<int64_t>(GetModuleHandleW(nullptr));

	_declspec(dllexport) void WriteFloat(uintptr_t address, float value) {
		*reinterpret_cast<float*>(address) = value;
	}

	_declspec(dllexport) float ReadFloat(uintptr_t address) {
		return *reinterpret_cast<float*>(address);
	}

	_declspec(dllexport) void WriteInt(uintptr_t address, int32_t value) {
		*reinterpret_cast<int32_t*>(address) = value;
	}

	_declspec(dllexport) int32_t ReadInt(uintptr_t address) {
		return *reinterpret_cast<int32_t*>(address);
	}

	//make 1 for each type then in c# make a function that will call the correct 1 given the type that u put in like Read<float> and it will call ReadFloat()

	_declspec(dllexport) int64_t GetLocalPlayer() {
		return reinterpret_cast<int64_t(__cdecl*)()>(WowBase + 0x1744E0)();
	}

	_declspec(dllexport) float GetScale() {
		return *reinterpret_cast<float*>(GetLocalPlayer() + 0x1820);
	}

	_declspec(dllexport) void SetScale(float value) {
		*reinterpret_cast<float*>(GetLocalPlayer() + 0x1820) = value;
	}
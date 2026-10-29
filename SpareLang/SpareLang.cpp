#include <iostream>
#include <vector>
#include <string>

using uc = unsigned char;
using us = unsigned short;
using namespace std;

struct Marker
{
    string Tag = "0";
    size_t Position = 1;
};
struct VariableID
{
    uc Type = 0;
    us ID = 0;
};

struct NumberVar     : VariableID        { size_t Value; };
struct StringVar        : VariableID        { size_t Value; };
struct BooleanVar    : VariableID        { bool Value; };

vector<NumberVar>       NUM_VARS = {};
vector<StringVar>          STR_VARS = {};
vector<BooleanVar>      BOOL_VARS = {};

vector<Marker> MARKERS = {};

string CODE = "";

int main()
{

}
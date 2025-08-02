namespace MyMonkeyApp.Models;

/// <summary>
/// 원숭이 정보를 나타내는 모델 클래스
/// </summary>
public class Monkey
{
    /// <summary>
    /// 원숭이의 이름
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 원숭이가 서식하는 지역
    /// </summary>
    public string Location { get; set; } = string.Empty;

    /// <summary>
    /// 원숭이에 대한 상세 설명
    /// </summary>
    public string Details { get; set; } = string.Empty;

    /// <summary>
    /// 원숭이 이미지 URL
    /// </summary>
    public string Image { get; set; } = string.Empty;

    /// <summary>
    /// 현재 개체수
    /// </summary>
    public int Population { get; set; }

    /// <summary>
    /// 서식지의 위도
    /// </summary>
    public double Latitude { get; set; }

    /// <summary>
    /// 서식지의 경도
    /// </summary>
    public double Longitude { get; set; }

    /// <summary>
    /// 원숭이 정보를 문자열로 표현
    /// </summary>
    /// <returns>원숭이의 기본 정보 문자열</returns>
    public override string ToString()
    {
        return $"{Name} - {Location} (개체수: {Population:N0})";
    }

    /// <summary>
    /// 원숭이의 상세 정보를 포맷된 문자열로 반환
    /// </summary>
    /// <returns>상세 정보가 포함된 문자열</returns>
    public string GetDetailedInfo()
    {
        return $"""
            이름: {Name}
            위치: {Location}
            개체수: {Population:N0}
            위도: {Latitude}
            경도: {Longitude}
            설명: {Details}
            이미지: {Image}
            """;
    }
}
